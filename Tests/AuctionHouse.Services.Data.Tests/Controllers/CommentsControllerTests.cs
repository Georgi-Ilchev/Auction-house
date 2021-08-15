namespace AuctionHouse.Services.Data.Tests.Controllers
{
    using System.Linq;

    using AuctionHouse.Web.Controllers;
    using AuctionHouse.Web.ViewModels.Comments;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static AuctionHouse.Services.Data.Tests.Data.Comments;
    //using static AuctionHouse.Services.Data.Tests.Data.Auctions;
    using System.Collections.Generic;
    using AuctionHouse.Data.Models;

    public class CommentsControllerTests
    {
        [Fact]
        public void All_ShouldReturnViewWithCorrectModelAndDataForCommentsCount()
        {
            MyController<CommentsController>
               .Instance(controller => controller
                   .WithData(AddComments()))
               .Calling(c => c.All(1, 1))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<ListCommentsViewModel>()
                   .Passing(m => m.Count == 10));
        }

        [Fact]
        public void All_ShouldReturnViewWithCorrectModelAndDataForComments()
        {
            MyController<CommentsController>
               .Instance(controller => controller
                   .WithData(AddComments()))
               .Calling(c => c.All(1, 1))
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<ListCommentsViewModel>()
                   .Passing(m => m.Comments.Count() == 0));
        }

        [Fact]
        public void Create_ShouldBeForAuthorizedUsersAndReturnView()
        {
            var auctions = AddAuctions();
            var id = auctions.FirstOrDefault(x => x.Id == 1).Id;

            MyMvc
                .Pipeline()
                .ShouldMap(request => request
                    .WithPath("/Comments/Create")
                    .WithUser())
                .To<CommentsController>(c => c.Create(id))
                .Which()
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();
        }

        public static IEnumerable<Auction> AddAuctions()
        {
            return Enumerable.Range(0, 10).Select(i => new Auction() { Id = i++});
        }
    }
}
