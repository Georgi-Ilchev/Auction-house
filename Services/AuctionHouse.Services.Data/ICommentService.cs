namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task CreateAsync(int auctionId, string userId, string content);

        Task Delete(string commentId);

        bool OwnedByUser(string userId, string commentId);
    }
}
