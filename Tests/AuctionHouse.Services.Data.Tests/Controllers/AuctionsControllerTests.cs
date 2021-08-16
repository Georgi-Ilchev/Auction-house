namespace AuctionHouse.Services.Data.Tests.Controllers
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.Controllers;
    using AuctionHouse.Web.ViewModels.Auctions;
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using Xunit;

    using static AuctionHouse.Services.Data.Tests.Data.Auctions;
    using static AuctionHouse.Services.Data.Tests.Data.Users;

    public class AuctionsControllerTests
    {
        [Fact]
        public void Create_ShouldBeForAuthorizedUsersAndReturnView()
        {
            MyMvc
                .Pipeline()
                .ShouldMap(request => request
                    .WithPath("/Auctions/Create")
                    .WithUser())
                .To<AuctionsController>(c => c.Create())
                .Which()
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void PostCreate_ShouldBeMapped()
        {
            MyRouting
                  .Configuration()
                  .ShouldMap(request => request
                  .WithPath("/Auctions/Create")
                  .WithMethod(HttpMethod.Post))
                  .To<AuctionsController>(c => c.Create(With.Any<CreateAuctionInputModel>()));
        }

        [Theory]
        [InlineData("auctionName", "description", 10, 1, 1)]
        public void PostCreate_ShouldBeForAuthorizedUsersAndReturnRedirectToAllAuctions(
            string auctionName,
            string description,
            decimal price,
            int categoryId,
            int activeDays
            )
        {
            MyController<AuctionsController>
                .Instance(instance => instance.WithUser())
                .Calling(c => c.Create(new CreateAuctionInputModel
                {
                    Name = auctionName,
                    Description = description,
                    Price = price,
                    CategoryId = categoryId,
                    ActiveDays = activeDays,
                    CreatedOn = DateTime.UtcNow,
                    ActiveTo = DateTime.UtcNow.AddDays(1),
                }))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .RestrictingForAuthorizedRequests())
                .ValidModelState()
                .Data(data => data
                    .WithSet<Auction>(auctions =>
                    {
                        auctions.Any(a =>
                            a.Name == auctionName &&
                            a.Description == description &&
                            a.Price == price &&
                            a.CategoryId == categoryId);
                    }));
        }

        [Fact]
        public void Edit_ShouldBeForAuthorizedUsersAndReturnView()
        {
            var auction = AddAuction();

            MyMvc
                .Pipeline()
                .ShouldMap(request => request
                    .WithPath("/Auctions/Edit/1")
                    .WithUser(user => user.WithIdentifier("UserId")))
                .To<AuctionsController>(c => c.Edit(auction.FirstOrDefault(x => x.Id == 1).Id))
                .Which()
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void AuctionByUser_ShouldReturnCorrectViewWithModelCount()
        {
            MyController<AuctionsController>
               .Instance(controller => controller
                   .WithUser(user => user.WithIdentifier("UserId"))
                   .WithData(AddAuction()))
               .Calling(c => c.AuctionByUser(1))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<ListAuctionsViewModel>()
                   .Passing(m => m.Count == 1));
        }

        [Fact]
        public void UserPurchases_ShouldReturnCorrectViewWithModelCount()
        {
            MyController<AuctionsController>
               .Instance(controller => controller
                   .WithUser(user => AddSingleUser())
                   .WithData(AddAuction()))
               .Calling(c => c.UserPurchases(1))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<ListAuctionsViewModel>()
                   .Passing(m => m.Count == 1));
        }
    }
}
