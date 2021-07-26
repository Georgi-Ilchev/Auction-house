namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Web.ViewModels.Comments;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task CreateAsync(int auctionId, string userId, string content);

        Task Delete(int commentId);

        bool OwnedByUser(string userId, int commentId);

        IEnumerable<CommentViewModel> GetAll(int auctionId);
    }
}
