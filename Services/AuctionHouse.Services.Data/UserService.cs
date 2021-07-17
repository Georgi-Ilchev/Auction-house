namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Users;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(int page, int itemsPerPage = 8)
        {
            var accounts = await this.userRepository.All()
                .AsQueryable()
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Balance = x.Balance,
                    Email = x.Email,
                    UserName = x.UserName,
                })
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return accounts;
        }

        public decimal GetUserBalance(string userId)
        {
            return this.userRepository.All().FirstOrDefault(x => x.Id == userId).Balance;
        }

        public UserViewModel GetUser(string userId)
        {
            var user = this.userRepository.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Balance = x.Balance,
                    Email = x.Email,
                    UserName = x.UserName,
                })
                .FirstOrDefault();

            return user;
        }

        public async Task AddMoneyAsync(string userId, decimal amount)
        {
            var user = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            user.Balance += amount;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task GetFromUser(string userId, decimal amount)
        {
            var user = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            user.Balance -= amount;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task GetToOwner(string ownerId, decimal amount)
        {
            var owner = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == ownerId);

            owner.Balance += amount;

            this.userRepository.Update(owner);
            await this.userRepository.SaveChangesAsync();
        }
    }
}
