namespace AuctionHouse.Services.Data.Tests.Controllers
{
    using System.Linq;

    using AuctionHouse.Web.Controllers;
    using AuctionHouse.Web.ViewModels;
    using AuctionHouse.Web.ViewModels.Home;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static AuctionHouse.Services.Data.Tests.Data.Auctions;
    using static AuctionHouse.Services.Data.Tests.Data.Categories;
    using static AuctionHouse.Services.Data.Tests.Data.Users;

    public class HomeControllerTests
    {
        [Fact]
        public void Index_ShouldReturnViewWithCorrectModelAndDataForAuctions()
        {
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
        public void Privacy_RouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Home/Privacy")
                .To<HomeController>(c => c.Privacy());
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

        [Fact]
        public void Error_ShouldReturnView()
        {
            MyMvc
                .Pipeline()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error())
                .Which()
                .ShouldReturn()
                .View();
        }
    }
}
