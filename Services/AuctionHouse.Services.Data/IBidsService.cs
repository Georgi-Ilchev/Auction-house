namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    public interface IBidsService
    {
        Task AddBidAsync(string userId, int auctionId, decimal price);

        decimal GetSumBids(int auctionId);
    }
}
