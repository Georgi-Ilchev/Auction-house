using AuctionHouse.Services.Data;
using AuctionHouse.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Post(CommentViewModel model)
        {
            return this.View();
        }
    }
}
