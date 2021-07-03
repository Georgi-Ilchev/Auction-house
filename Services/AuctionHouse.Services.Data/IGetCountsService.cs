namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Services.Data.Models;

    public interface IGetCountsService
    {
        CountsDto GetCounts();
    }
}
