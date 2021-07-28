namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Bids;

    public interface IBidsService
    {
        Task AddBidAsync(string userId, int auctionId, decimal price);

        Task AddBidToHistory(string userId, int auctionId, decimal price);

        Task ReturnBids(string userId, int auctionId);

        decimal GetSumBids(int auctionId);

        decimal GetDbUserBalance(string userId);

        decimal GetUserBids(string userId, int auctionId);

        LastUserBidViewModel GetUser(string userId, string email);

        Task UpdateAsync(int id, LastUserBidViewModel input);

        Task GetMoneyFromDbUser(string userId, decimal amount);

        bool CheckForCorrectBid(decimal bid);

        //UpdateAuctionBidsViewModel GetUpdate(int auctionId, decimal currentBid, string lastBidder);
    }
}
