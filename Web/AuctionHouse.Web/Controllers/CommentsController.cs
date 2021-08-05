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
        public IActionResult All(int id, int pageNum = 1)
        {
            const int ItemsPerPage = 8;

            if (pageNum <= 0)
            {
                return this.NotFound();
            }

            var comments = this.commentService.GetAll(id, pageNum, ItemsPerPage);

            var viewModel = new ListCommentsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = pageNum,
                Comments = comments,
                AuctionsCount = this.commentService.GetCommentsCount(id),
            };

            this.ViewBag.AuctionId = id;

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            var viewModel = new CreateCommentInputModel();
            viewModel.Id = id;

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int id, CreateCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.commentService.CreateAsync(id, userId, input.Content);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction(nameof(this.All), new { id = id });
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

            return this.RedirectToAction(nameof(this.All), new { id = auctionId });
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
