namespace AuctionHouse.Web.Controllers
{
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Auctions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : BaseController
    {
        private readonly IAuctionService auctionService;

        public SearchController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Search(int id = 1)
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
                Auctions = await this.auctionService.GetAll<ListAuctionViewModel>(id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetAuctionsCount(),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public PartialViewResult SearchAuctions(string searchText, int id = 1)
        {
            const int ItemsPerPage = 8;

            var viewModel = new ListAuctionsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = this.auctionService.GetSearch<ListAuctionViewModel>(searchText, id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetAuctionsCount(),
            };

            return this.PartialView("_GridView", viewModel);
        }
    }
}
