namespace AuctionHouse.Web.Controllers
{
    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Auctions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AuctionsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IAuctionService auctionService;

        public AuctionsController(ICategoriesService categoriesService, IAuctionService auctionService)
        {
            this.categoriesService = categoriesService;
            this.auctionService = auctionService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAuctionInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuctionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.auctionService.CreateAsync(input);

            // TODO
            return this.Redirect("/");
        }
    }
}
