namespace AuctionHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        //Task<IEnumerable<T>> GetAll<T>(int page, int itemsPerPage = 8);

        decimal GetUserBalance(string userId);
    }
}
