namespace AuctionHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Claims;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Services.Data.Models;
    using AuctionHouse.Web.ViewModels;
    using AuctionHouse.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService getCountsService;
        private readonly IAuctionService auctionService;
        private readonly IUserService userService;
        private readonly IMemoryCache cache;

        public HomeController(
            IGetCountsService getCountsService,
            IAuctionService auctionService,
            IUserService userService,
            IMemoryCache cache)
        {
            this.getCountsService = getCountsService;
            this.auctionService = auctionService;
            this.userService = userService;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            const string allWeeklyAukctions = "LatesAuctionsCount";
            const string indexViewModel = "IndexViewModel";
            const string auctionsAndCategories = "AuctionsAndCategories";

            if (this.User.Identity.IsAuthenticated)
            {
                var weeklyAuctions = this.cache.Get<List<IndexPageAuctionViewModel>>(allWeeklyAukctions);
                var counts = this.cache.Get<CountsDto>(auctionsAndCategories);

                if (weeklyAuctions == null)
                {
                    weeklyAuctions = this.auctionService.GetWeeklyAuctions<IndexPageAuctionViewModel>();

                    var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                    this.cache.Set(allWeeklyAukctions, weeklyAuctions, cacheOptions);
                }

                if (counts == null)
                {
                    counts = this.getCountsService.GetCounts();

                    var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                    this.cache.Set(auctionsAndCategories, counts, cacheOptions);
                }

                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var viewModel = new IndexViewModel
                {
                    AuctionsCount = counts.AuctionsCount,
                    CategoriesCount = counts.CategoriesCount,
                    Balance = this.userService.GetUserBalance(userId),
                    VirtualBalance = this.userService.GetVirtualUserBalance(userId),
                    WeeklyAuctions = weeklyAuctions,
                };

                return this.View(viewModel);
            }
            else
            {
                var model = this.cache.Get<IndexViewModel>(indexViewModel);

                if (model == null)
                {
                    var counts = this.getCountsService.GetCounts();
                    model = new IndexViewModel
                    {
                        AuctionsCount = counts.AuctionsCount,
                        CategoriesCount = counts.CategoriesCount,
                        WeeklyAuctions = this.auctionService.GetWeeklyAuctions<IndexPageAuctionViewModel>(),
                    };

                    var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
                    this.cache.Set(indexViewModel, model, cacheOptions);
                }

                //var counts = this.getCountsService.GetCounts();
                //var viewModel = new IndexViewModel
                //{
                //    AuctionsCount = counts.AuctionsCount,
                //    CategoriesCount = counts.CategoriesCount,
                //    WeeklyAuctions = this.auctionService.GetWeeklyAuctions<IndexPageAuctionViewModel>(),
                //};

                return this.View(model);
            }
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
