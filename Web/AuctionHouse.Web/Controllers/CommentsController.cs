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

            return this.RedirectToAction(nameof(this.Comment));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id, string commentId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.commentService.OwnedByUser(userId, commentId))
            {
                return this.Unauthorized();
            }

            if (commentId == string.Empty)
            {
                return this.NotFound();
            }

            await this.commentService.Delete(commentId);

            return this.RedirectToAction(nameof(this.Comment));
        }
    }
}
