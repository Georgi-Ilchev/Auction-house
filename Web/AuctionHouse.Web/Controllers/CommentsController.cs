namespace AuctionHouse.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IAuctionService auctionService;

        public CommentsController(ICommentService commentService, IAuctionService auctionService)
        {
            this.commentService = commentService;
            this.auctionService = auctionService;
        }

        [Authorize]
        public IActionResult Comment(int id)
        {
            var input = this.auctionService.GetById<CommentAuctionInputModel>(id);

            return this.View(input);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment(int id, CommentAuctionInputModel model)
        {
            var auctionId = model.Id;

            if (!this.auctionService.IsAuctionExisting(auctionId))
            {
                return this.Redirect("/");
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await this.commentService.CreateAsync(auctionId, userId, model.Content);

            // think for redirect
            return this.RedirectToAction("SingleAuction", "Auctions", new { auctionId = id });
        }
    }
}
