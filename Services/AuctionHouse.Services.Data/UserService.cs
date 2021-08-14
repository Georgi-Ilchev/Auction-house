namespace AuctionHouse.Services.Data
{
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
        private readonly IDeletableEntityRepository<Auction> auctionsRepository;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Auction> auctionsRepository)
        {
            this.userRepository = userRepository;
            this.auctionsRepository = auctionsRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(int page, int itemsPerPage = 8)
        {
            var accounts = await this.userRepository.All()
                .AsQueryable()
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Balance = x.Balance,
                    VirtualBalance = x.VirtualBalance,
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
            return this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == userId).Balance;
        }

        public decimal GetVirtualUserBalance(string userId)
        {
            return this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == userId).VirtualBalance;
        }

        public UserViewModel GetUser(string userId)
        {
            var user = this.userRepository.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Balance = x.Balance,
                    VirtualBalance = x.VirtualBalance,
                    Email = x.Email,
                    UserName = x.UserName,
                })
                .FirstOrDefault();

            return user;
        }

        public UserViewModel GetLastBidUser(string email)
        {
            var user = this.userRepository.AllAsNoTracking()
                .Where(x => x.Email == email)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    Balance = x.Balance,
                    VirtualBalance = x.VirtualBalance,
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
            user.VirtualBalance += amount;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task GetFromUser(string userId, decimal amount, decimal virtualBids)
        {
            var user = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            var virtualAmount = amount - virtualBids;

            user.Balance -= amount;
            user.VirtualBalance -= virtualAmount;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task GetToOwner(string ownerId, decimal amount, int auctionId)
        {
            var owner = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == ownerId);

            owner.Balance += amount;
            owner.VirtualBalance += amount;

            var dbAuction = this.auctionsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == auctionId);

            dbAuction.IsPaid = true;

            this.userRepository.Update(owner);
            this.auctionsRepository.Update(dbAuction);

            await this.userRepository.SaveChangesAsync();
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task UpdateDbUser(string userId, decimal amount)
        {
            var dbUser = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            dbUser.Balance -= amount;
            dbUser.VirtualBalance -= amount;

            this.userRepository.Update(dbUser);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task UpdateDbUserVirtualBalance(string userId, decimal amount)
        {
            var dbUser = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            dbUser.VirtualBalance -= amount;

            this.userRepository.Update(dbUser);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task UpdateDbUserVirtualBalanceWithPrice(string userId, decimal amount, decimal auctionPrice)
        {
            var dbUser = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            dbUser.VirtualBalance -= amount + auctionPrice;

            this.userRepository.Update(dbUser);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task UpdateReturningBids(string userId, decimal amount)
        {
            var dbUser = this.userRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == userId);

            dbUser.VirtualBalance += amount;

            this.userRepository.Update(dbUser);
            await this.userRepository.SaveChangesAsync();
        }

        public int UsersCount()
        {
            return this.userRepository.AllAsNoTracking().Count();
        }
    }
}
