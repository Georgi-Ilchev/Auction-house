namespace AuctionHouse.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Administration.Auctions;
    using AuctionHouse.Web.ViewModels.Auctions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class AuctionsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IAuctionService auctionService;
        private readonly IWebHostEnvironment environment;

        public AuctionsController(ICategoriesService categoriesService, IAuctionService auctionService, IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.auctionService = auctionService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateAuctionInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAuctionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.auctionService.CreateAsync(input, userId, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // TODO
            return this.Redirect("/Auctions/All");
        }

        [Authorize]
        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new ListAuctionsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = this.auctionService.GetAll<ListAuctionViewModel>(id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetAuctionsCount(),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult SingleAuction(int auctionId)
        {
            var auction = this.auctionService.GetById<SingleAuctionViewModel>(auctionId);
            /*auction.Price + auction.BidsAmount.Sum(x=>x.bid)*/

            // auction.BidsAmount = auction.Price + auction.BidsAmount.

            return this.View(auction);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int auctionId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.auctionService.OwnedByUser(userId, auctionId))
            {
                return this.Unauthorized();
            }

            await this.auctionService.Delete(auctionId);

            return this.Redirect("/Auctions/All");
        }

        public bool CanUserDeleteAuction(int auctionId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userOwnAuction = this.auctionService.OwnedByUser(userId, auctionId);

            if (!userOwnAuction)
            {
                return false;
            }

            return true;
        }

        // move this to administration in web.viewModels
        [HttpGet]
        public IActionResult AuctionOfTheWeek()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AuctionOfTheWeek(PromoteAuctionInputModel input, int auctionId)
        {
            await this.auctionService.PromoteAuctionOfWeek(input.PromoteEnd, auctionId);
            return this.Redirect("/Views/Auctions/AuctionOfTheWeek");
        }
    }
}
