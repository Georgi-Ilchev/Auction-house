namespace AuctionHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Auctions;

    public interface IAuctionService
    {
        Task CreateAsync(CreateAuctionInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8);

        int GetAuctionsCount();
    }
}
