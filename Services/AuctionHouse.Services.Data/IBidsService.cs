namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBidsService
    {
        Task AddBidAsync(string userId, int auctionId, decimal price);

        decimal GetSumBids(int auctionId);

        //Bid GetLastBidder();
    }
}
