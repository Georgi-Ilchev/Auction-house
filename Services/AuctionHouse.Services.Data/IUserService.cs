namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Web.ViewModels.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync(int page, int itemsPerPage = 8);

        Task AddMoneyAsync(string userId, decimal amount);

        UserViewModel GetUser(string userId);

        decimal GetUserBalance(string userId);
    }
}
