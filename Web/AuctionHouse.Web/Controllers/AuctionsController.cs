namespace AuctionHouse.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Auctions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class AuctionsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IAuctionService auctionService;

        public AuctionsController(ICategoriesService categoriesService, IAuctionService auctionService)
        {
            this.categoriesService = categoriesService;
            this.auctionService = auctionService;
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

            await this.auctionService.CreateAsync(input, userId);

            // TODO
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            var viewModel = new ListAuctionsViewModel
            {
                PageNumber = id,
                Auctions = this.auctionService.GetAll<ListAuctionViewModel>(id, 8),
            };

            return this.View(viewModel);
        }

        public IActionResult AuctionOfTheWeek()
        {
            return this.View();
        }
    }
}
