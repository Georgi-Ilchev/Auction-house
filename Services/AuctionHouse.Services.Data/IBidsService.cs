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

        Task ReturnBids(string userId, int auctionId, decimal auctionPrice);

        decimal GetSumBids(int auctionId);

        decimal GetDbUserBalance(string userId);

        decimal GetUserBids(string userId, int auctionId);

        LastUserBidViewModel GetUser(string userId, string email);

        Task UpdateAsync(int id, LastUserBidViewModel input);

        Task GetMoneyFromDbUser(string userId, decimal amount);

        bool CheckForCorrectBid(decimal bid);

        bool CanUserMakeBid(string userId);



        decimal GetAuctionPrice(int auctionId);

        Task GetMoneyFromDbUserPlusPrice(string userId, decimal amount, decimal price);

        bool AmILastBidder(string userId, int auctionId);

        //UpdateAuctionBidsViewModel GetUpdate(int auctionId, decimal currentBid, string lastBidder);
    }
}
