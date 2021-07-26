namespace AuctionHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Users;

    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync(int page, int itemsPerPage = 8);

        Task AddMoneyAsync(string userId, decimal amount);

        UserViewModel GetUser(string userId);

        UserViewModel GetLastBidUser(string email);

        decimal GetUserBalance(string userId);

        decimal GetVirtualUserBalance(string userId);

        Task GetFromUser(string userId, decimal amount, decimal virtualBids);

        Task GetToOwner(string ownerId, decimal amount, int auctionId);

        Task UpdateDbUser(string userId, decimal amount);

        Task UpdateDbUserVirtualBalance(string userId, decimal amount);

        Task UpdateReturningBids(string userId, decimal amount);
    }
}
