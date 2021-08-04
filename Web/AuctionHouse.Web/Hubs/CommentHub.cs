using AuctionHouse.Services.Data;
using AuctionHouse.Web.ViewModels.Comments;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionHouse.Web.Hubs
{
    public class CommentHub : Hub
    {
        private readonly ICommentService commentService;

        public CommentHub(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public async Task SendComment(string content, int auctionId)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            var userId = this.Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.commentService.CreateAsync(auctionId, userId, content);

            await this.Clients.All.SendAsync("SendComment", new CommentViewModel
            {
                AuctionId = auctionId,
                Content = content,
                UserId = userId,
            });
        }
    }
}
