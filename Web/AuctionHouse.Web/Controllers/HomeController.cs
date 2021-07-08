namespace AuctionHouse.Web.Controllers
{
    using System.Diagnostics;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels;
    using AuctionHouse.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;
        private readonly IAuctionService auctionService;

        public HomeController(IGetCountsService getCountsService, IAuctionService auctionService)
        {
            this.getCountsService = getCountsService;
            this.auctionService = auctionService;
        }

        public IActionResult Index()
        {
            var counts = this.getCountsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                AuctionsCount = counts.AuctionsCount,
                CategoriesCount = counts.CategoriesCount,
                WeeklyAuctions = this.auctionService.GetWeeklyAuctions<IndexPageAuctionViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
