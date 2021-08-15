namespace AuctionHouse.Services.Data.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.Controllers;
    using AuctionHouse.Web.ViewModels;
    using AuctionHouse.Web.ViewModels.Home;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewWithCorrectModelAndDataForAuctions()
        {
            //return MyMvc
            //    .Pipeline()
            //    .ShouldMap("/")
            //    .To<HomeController>(c => c.Index())
            //    .Which(controller => controller
            //        .WithData(AddAuctions()))
            //    .ShouldReturn()
            //    .View(view => view
            //        .WithModelOfType<IndexViewModel>()
            //        .Passing(m => m.AuctionsCount.HaveCount(3)));

            MyController<HomeController>
               .Instance(controller => controller
                   .WithData(AddAuctions()))
               .Calling(c => c.Index())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<IndexViewModel>()
                   .Passing(m => m.AuctionsCount == 10));
        }

        [Fact]
        public void Index_ShouldReturnViewWithCorrectModelAndDataForCategory()
        {
            MyController<HomeController>
               .Instance(controller => controller
                   .WithData(AddCategories()))
               .Calling(c => c.Index())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<IndexViewModel>()
                   .Passing(m => m.CategoriesCount == 10));
        }

        [Fact]
        public void Index_ShouldReturnViewWithCorrectModelAndDataForUserBalance()
        {
            MyController<HomeController>
               .Instance(controller => controller
                   .WithData(AddUser()))
               .Calling(c => c.Index())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<IndexViewModel>()
                   .Passing(m => m.Balance == 0));
        }

        [Fact]
        public void Index_ShouldReturnViewWithCorrectModelAndDataForUserVirtualBalance()
        {
            MyController<HomeController>
               .Instance(controller => controller
                   .WithData(AddUser()))
               .Calling(c => c.Index())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<IndexViewModel>()
                   .Passing(m => m.VirtualBalance == 0));
        }

        [Fact]
        public void Index_ShouldReturn0ViewWithCorrectModelAndDataForWeeklyAuctions()
        {
            MyController<HomeController>
               .Instance(controller => controller
                   .WithData(AddAuctions()))
               .Calling(c => c.Index())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<IndexViewModel>()
                   .Passing(m => m.WeeklyAuctions.Count == 0));
        }

        [Fact]
        public void Index_ShouldReturnViewWithCorrectModelAndDataForWeeklyAuctions()
        {
            MyMvc
                 .Pipeline()
                 .ShouldMap("/")
                 .To<HomeController>(c => c.Index())
                 .Which(controller => controller
                     .WithData(AddWeeklyAuctions()))
                 .ShouldReturn()
                 .View(view => view
                     .WithModelOfType<IndexViewModel>()
                     .Passing(m => m.WeeklyAuctions.Count() == 10));
        }

        [Fact]
        public void Privacy_ShouldCorrectView()
        {
            MyController<HomeController>
               .Calling(c => c.Privacy())
               .ShouldReturn()
               .View();
        }

        [Fact]
        public void Error_ShouldReturnCorrectView()
        {
            MyController<HomeController>
               .Calling(c => c.Error())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<ErrorViewModel>());
        }

        private static IEnumerable<Auction> AddAuctions()
        {
            return Enumerable.Range(0, 10).Select(i => new Auction());
        }

        private static IEnumerable<Auction> AddWeeklyAuctions()
        {
            return Enumerable.Range(0, 10).Select(i => new Auction()
            {
                IsAuctionOfTheWeek = true,
            });
        }

        private static IEnumerable<Category> AddCategories()
        {
            return Enumerable.Range(0, 10).Select(i => new Category());
        }

        private static IEnumerable<ApplicationUser> AddUser()
        {
            return Enumerable.Range(0, 10).Select(i => new ApplicationUser());
        }
    }
}
