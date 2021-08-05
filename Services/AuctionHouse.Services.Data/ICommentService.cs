namespace AuctionHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Comments;

    public interface ICommentService
    {
        Task CreateAsync(int auctionId, string userId, string content);

        Task Delete(int commentId);

        IEnumerable<CommentViewModel> GetAll(int auctionId, int page, int itemsPerPage = 8);

        int GetCommentsCount(int auctionId);

        bool OwnedByUser(string userId, int commentId);
    }
}
