namespace AuctionHouse.Web.Controllers
{
    using System;
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
        public IActionResult All(int auctionId, int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var comments = this.commentService.GetAll(auctionId, id, ItemsPerPage);

            var viewModel = new ListCommentsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Comments = comments,
                AuctionsCount = this.commentService.GetCommentsCount(auctionId),
            };

            this.ViewBag.AuctionId = auctionId;

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create(int auctionId)
        {
            var viewModel = new CreateCommentInputModel();
            viewModel.Id = auctionId;

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int auctionId, CreateCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.commentService.CreateAsync(auctionId, userId, input.Content);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.All), new { auctionId = auctionId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int commentId, int auctionId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.commentService.OwnedByUser(userId, commentId))
            {
                return this.Unauthorized();
            }

            if (commentId == 0)
            {
                return this.NotFound();
            }

            await this.commentService.Delete(commentId);

            return this.RedirectToAction(nameof(this.All), new { auctionId = auctionId });
        }

        // test
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

            if (!this.ModelState.IsValid)
            {
                //return this.View(model);
                return this.BadRequest();
            }

            if (!this.auctionService.IsAuctionExisting(auctionId))
            {
                return this.Redirect("/");
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await this.commentService.CreateAsync(auctionId, userId, model.Content);

            return this.RedirectToAction(nameof(this.Comment));
        }
    }
}
