namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Bids;

    public interface IBidsService
    {
        Task AddBidAsync(string userId, int auctionId, decimal price);

        Task AddBidAsyncPlusPrice(string userId, int auctionId, decimal price, decimal auctionPrice);

        Task AddBidToHistory(string userId, int auctionId, decimal price);

        Task AddBidToHistoryPlusPrice(string userId, int auctionId, decimal price, decimal auctionPrice);

        Task ReturnBids(string userId, int auctionId);

        Task UpdateAsync(int id, LastUserBidViewModel input);

        Task GetMoneyFromDbUser(string userId, decimal amount);

        LastUserBidViewModel GetUser(string userId, string email);

        decimal GetSumBids(int auctionId);

        decimal GetDbUserStaticBalance(string userId);

        decimal GetDbUserBalance(string userId);

        decimal GetUserBids(string userId, int auctionId);

        decimal GetAuctionPrice(int auctionId);

        bool CheckForCorrectBid(decimal bid);

        bool CanUserMakeBid(string userId, decimal bid);

        bool AmILastBidder(string userId, int auctionId);

        bool AmIFirstBidder(int auctionId);
    }
}
