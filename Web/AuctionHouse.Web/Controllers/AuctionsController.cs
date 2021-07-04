namespace AuctionHouse.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
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
            return this.Redirect("/");
        }

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

        public IActionResult AuctionOfTheWeek()
        {
            return this.View();
        }
    }
}
