namespace AuctionHouse.Web.Controllers
{
    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Search;
    using Microsoft.AspNetCore.Mvc;

    public class SearchAuctionsController : BaseController
    {
        private readonly IAuctionService auctionService;

        public SearchAuctionsController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Listing(SearchInputModel input)
        {
            return this.View();
        }
    }
}
