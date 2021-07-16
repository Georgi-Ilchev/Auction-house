namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Web.ViewModels.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync(int page, int itemsPerPage = 8);

        decimal GetUserBalance(string userId);
    }
}
