namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    public interface IBidsService
    {
        Task SetBidAsync(string userId, int auctionId, decimal price);
    }
}
