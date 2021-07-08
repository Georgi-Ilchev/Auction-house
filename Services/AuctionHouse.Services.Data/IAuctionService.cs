namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Auctions;

    public interface IAuctionService
    {
        Task CreateAsync(CreateAuctionInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8);

        IEnumerable<T> GetWeeklyAuctions<T>();

        int GetAuctionsCount();

        T GetById<T>(int id);

        bool OwnedByUser(string userId, int auctionId);

        Task PromoteAuctionOfWeek(DateTime promoteEnd, int auctionId);

        Task UnPromoteAuctionOfWeek(int auctionId);

        Task Delete(int auctionId);
    }
}
