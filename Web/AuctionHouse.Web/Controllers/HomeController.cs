namespace AuctionHouse.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using AuctionHouse.Data;
    using AuctionHouse.Web.ViewModels;
    using AuctionHouse.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext data;

        public HomeController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                AuctionsCount = this.data.Auctions.Count(),
                CategoriesCount = this.data.Categories.Count(),
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
