namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Auctions;

    public interface IAuctionService
    {
        Task<IEnumerable<ListAuctionViewModel>> GetAll<TListAuctionViewModel>(int page, int itemsPerPage = 8);

        Task<IEnumerable<ListAuctionViewModel>> GetAllForSearch<TListAuctionViewModel>(int category, int page, int itemsPerPage = 8);

        Task<IEnumerable<ListAuctionViewModel>> GetAllPending<TListAuctionViewModel>(int page, int itemsPerPage = 8);

        IEnumerable<T> GetUserAuctions<T>(string userId, int page, int itemsPerPage = 8);

        IEnumerable<T> GetAllUserPurchases<T>(string userEmail, int page, int itemsPerPage = 8);

        IEnumerable<T> GetAllUserSales<T>(string userId, int page, int itemsPerPage = 8);

        IEnumerable<T> GetSearch<T>(string search, int page, int itemsPerPage = 8);

        List<T> GetWeeklyAuctions<T>();

        int GetAuctionsCount();

        int GetPendingAuctionsCount();

        int GetAuctionsCountByCategory(int category);

        int GetUserAuctionsCount(string userId);

        int GetUserPurchasesCount(string userEmail);

        int GetUserSalesCount(string userId);

        T GetById<T>(int id);

        T GetByIdWithPaging<T>(int id, int page, int itemsPerPage = 8);

        bool OwnedByUser(string userId, int auctionId);

        bool IsAuctionExisting(int auctionId);

        bool IsThereLastBidder(int auctionId);

        Task CreateAsync(CreateAuctionInputModel input, string userId, string imagePath);

        Task PromoteAuctionOfWeek(DateTime promoteEnd, int auctionId);

        Task UnPromoteAuctionOfWeek(int auctionId);

        Task UpdateAsync(int id, EditAuctionInputModel input);

        Task Delete(int auctionId);

        Task UpdateDbAuction(int auctionId);

        Task ApproveAuction(int auctionId);
    }
}
