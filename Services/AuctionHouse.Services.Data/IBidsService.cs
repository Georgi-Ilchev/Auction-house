namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Bids;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBidsService
    {
        Task AddBidAsync(string userId, int auctionId, decimal price);

        decimal GetSumBids(int auctionId);

        LastUserBidViewModel GetUser(string userId, string email);

        //Bid GetLastBidder();
    }
}
