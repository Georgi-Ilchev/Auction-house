namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8)
        {
            //var accounts = this.userRepository.All()
            //    .OrderByDescending(x => x.Id)
            //    .Skip((page - 1) * itemsPerPage)
            //    .Take(itemsPerPage)
            //    .ToList();

            //return (T)accounts;

            throw new NotImplementedException();
        }

        public decimal GetUserBalance(string userId)
        {
            return this.userRepository.All().FirstOrDefault(x => x.Id == userId).Balance;
        }
    }
}
