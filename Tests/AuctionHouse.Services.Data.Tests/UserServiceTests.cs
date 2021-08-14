namespace AuctionHouse.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Data.Repositories;
    using AuctionHouse.Services.Mapping;
    using AuctionHouse.Web.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class UserServiceTests
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext db;

        private EfDeletableEntityRepository<Auction> auctionRepository;
        private EfDeletableEntityRepository<ApplicationUser> userRepository;

        private IUserService userService;

        public UserServiceTests()
        {
            this.optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.db = new ApplicationDbContext(this.optionsBuilder.Options);

            this.auctionRepository = new EfDeletableEntityRepository<Auction>(this.db);
            this.userRepository = new EfDeletableEntityRepository<ApplicationUser>(this.db);

            this.userService = new UserService(this.userRepository, this.auctionRepository);

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetType().Assembly);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfAllUsers()
        {
            await this.userRepository.AddAsync(this.AddUser());
            this.db.ChangeTracker.Clear();
            await this.userRepository.AddAsync(this.AddAnotherUser());
            var result = await this.userService.GetAllAsync(1);

            Assert.Contains(result, c => c.Email == "user@gmail.com" && c.Id == "userId");
            Assert.Contains(result, c => c.Email == "another@gmail.com" && c.Id == "anotherId");
            Assert.DoesNotContain(result, c => c.Email == "notcontaining@gmail.com" && c.Id == "id");
        }

        [Fact]
        public void GetUserBalance_ShouldGetCurrentUserBalance()
        {
            var user = this.AddUser();
            var result = this.userService.GetUserBalance(user.Id);

            Assert.Equal(3000, result);
        }

        [Fact]
        public void GetVirtualUserBalance_ShouldGetCurrentUserVirtualBalance()
        {
            var user = this.AddUser();
            var result = this.userService.GetVirtualUserBalance(user.Id);

            Assert.Equal(2000, result);
        }

        [Fact]
        public void GetUser_ShouldGetUserByIdFromDb()
        {
            var user = this.AddUser();

            var result = this.userService.GetUser("userId");

            Assert.Equal("userId", result.Id);
            Assert.Equal("user@gmail.com", result.Email);
            Assert.Equal(2000, result.VirtualBalance);
        }

        [Fact]
        public void GetLastBidUser_ShouldGetLastBidderByEmail()
        {
            var user = this.AddUser();

            var result = this.userService.GetLastBidUser("user@gmail.com");

            Assert.Equal("userId", result.Id);
            Assert.Equal("user@gmail.com", result.Email);
            Assert.Equal(2000, result.VirtualBalance);
        }

        [Fact]
        public async Task AddMoneyAsync_ShouldAddMoneyToUserByAdmin()
        {
            var user = this.AddUser();
            this.db.ChangeTracker.Clear();
            await this.userService.AddMoneyAsync("userId", 180);

            var usersBalance = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(3180, usersBalance.Balance);
            Assert.Equal(2180, usersBalance.VirtualBalance);
        }

        [Fact]
        public async Task GetFromUser_ShouldGoDownUserBalanceWhenHePaysToOwner()
        {
            var user = this.AddUser();
            this.db.ChangeTracker.Clear();
            await this.userService.GetFromUser("userId", 200, 50);

            var usersBalance = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(2800, usersBalance.Balance);
            Assert.Equal(1850, usersBalance.VirtualBalance);
        }

        [Fact]
        public async Task GetToOwner_ShouldGoUpUserBalanceWhenHeSuccessfullySaleAuction()
        {
            this.AddAuction();
            this.db.ChangeTracker.Clear();
            await this.userService.GetToOwner("userId", 200, 1);

            var usersBalance = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(3200, usersBalance.Balance);
            Assert.Equal(2200, usersBalance.VirtualBalance);
        }

        [Fact]
        public async Task GetToOwner_ShouldMakeAuctionIsPaidToTrue()
        {
            this.AddAuction();
            this.db.ChangeTracker.Clear();
            await this.userService.GetToOwner("userId", 200, 1);
            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 1);

            var result = auction.IsPaid;

            Assert.True(result);
        }

        [Fact]
        public async Task GetToOwner_AuctionIsPaidShouldBeFalseBeforeGetToOwnerMethod()
        {
            var auction = this.AddAuction();
            this.db.ChangeTracker.Clear();
            await this.userService.GetToOwner("userId", 200, 1);
            var result = auction.IsPaid;

            Assert.False(result);
        }

        [Fact]
        public async Task UpdateDbUser_ShouldGoDownUserBalanceButIdontUseItAnywhere()
        {
            this.AddUser();
            this.db.ChangeTracker.Clear();
            await this.userService.UpdateDbUser("userId", 20);
            var result = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(2980, result.Balance);
            Assert.Equal(1980, result.VirtualBalance);
        }

        [Fact]
        public async Task UpdateDbUserVirtualBalance_ShouldGoDownUserVirtualBalanceWhenHeMakeABid()
        {
            this.AddUser();
            this.db.ChangeTracker.Clear();
            await this.userService.UpdateDbUserVirtualBalance("userId", 120);
            var result = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(1880, result.VirtualBalance);
        }

        [Fact]
        public async Task UpdateDbUserVirtualBalanceWithPrice_ShouldGoDownUserVirtualBalanceWhenHeMakeBidAndItIsFirstBidder()
        {
            this.AddUser();
            this.db.ChangeTracker.Clear();
            await this.userService.UpdateDbUserVirtualBalanceWithPrice("userId", 120, 30);
            var result = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(1850, result.VirtualBalance);
        }

        [Fact]
        public async Task UpdateReturningBids_ShouldReturnBidsToUserWhenOtherUserMakeBidOverHim()
        {
            this.AddUser();
            this.db.ChangeTracker.Clear();
            await this.userService.UpdateReturningBids("userId", 100);
            var result = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == "userId");

            Assert.Equal(2100, result.VirtualBalance);
        }

        [Fact]
        public void UsersCount_ShouldReturn0WhenThereIsNoUsers()
        {
            var result = this.userService.UsersCount();

            Assert.Equal(0, result);
        }

        [Fact]
        public void UsersCount_ShouldReturnAllUsersCount()
        {
            this.AddUser();
            this.AddAnotherUser();
            var result = this.userService.UsersCount();

            Assert.Equal(2, result);
        }

        private ApplicationUser AddUser()
        {
            var user = new ApplicationUser()
            {
                Id = "userId",
                Email = "user@gmail.com",
                IsDeleted = false,
                PasswordHash = "UnhashedPass2021",
                UserName = "user@gmail.com",
                CreatedOn = DateTime.UtcNow,
                NormalizedUserName = "USER@GMAIL.COM",
                NormalizedEmail = "USER@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = "SecurityStamp",
                ConcurrencyStamp = "ConcurrencyStamp",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Balance = 3000,
                VirtualBalance = 2000,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user;
        }

        private ApplicationUser AddAnotherUser()
        {
            var user = new ApplicationUser()
            {
                Id = "anotherId",
                Email = "another@gmail.com",
                IsDeleted = false,
                PasswordHash = "UnhashedPass2021",
                UserName = "another@gmail.com",
                CreatedOn = DateTime.UtcNow,
                NormalizedUserName = "ANOTHER@GMAIL.COM",
                NormalizedEmail = "ANOTHER@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = "SecurityStamp",
                ConcurrencyStamp = "ConcurrencyStamp",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Balance = 3000,
                VirtualBalance = 3000,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user;
        }

        private Auction AddAuction()
        {
            var auction = new Auction()
            {
                Name = "old saxophone",
                Description = "description",
                Price = 10,
                CurrentPrice = 10,
                ActiveTo = DateTime.UtcNow.AddDays(2),
                User = this.AddUser(),
                CategoryId = 1,
            };

            this.db.Auctions.Add(auction);
            this.db.SaveChanges();

            return auction;
        }
    }
}
