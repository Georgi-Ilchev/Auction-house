using AuctionHouse.Data;
using AuctionHouse.Data.Models;
using AuctionHouse.Data.Repositories;
using AuctionHouse.Web.ViewModels.Bids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuctionHouse.Services.Data.Tests
{
    public class BidsServiceTests
    {
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext db;

        private EfRepository<Bid> bidRepository;
        private EfDeletableEntityRepository<Auction> auctionRepository;
        private EfDeletableEntityRepository<History> historyRepository;
        private EfDeletableEntityRepository<ApplicationUser> userRepository;

        private IUserService userService;
        private IBidsService bidsService;

        public BidsServiceTests()
        {
            this.optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.db = new ApplicationDbContext(this.optionsBuilder.Options);
            this.bidRepository = new EfRepository<Bid>(this.db);
            this.auctionRepository = new EfDeletableEntityRepository<Auction>(this.db);
            this.historyRepository = new EfDeletableEntityRepository<History>(this.db);
            this.userRepository = new EfDeletableEntityRepository<ApplicationUser>(this.db);

            this.userService = new UserService(userRepository, auctionRepository);
            this.bidsService = new BidsService(bidRepository, auctionRepository, historyRepository, userService);
        }

        [Fact]
        public async Task AddBidAsync_ShouldAddNewBid()
        {
            await this.bidsService.AddBidAsync("userId", 1, 20);

            var bid = this.db.Bids.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(20, bid.BidAmount);
        }

        [Fact]
        public async Task AddBidAsync_ShouldAddBidAmountToAlreadyExistBid()
        {
            await this.bidsService.AddBidAsync("userId", 1, 20);
            await this.bidsService.AddBidAsync("userId", 1, 30);

            var bid = this.db.Bids.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(50, bid.BidAmount);
        }

        [Fact]
        public async Task AddBidAsync_ShouldWorkCorrect()
        {
            await this.bidsService.AddBidAsync("userId", 1, 20);
            await this.bidsService.AddBidAsync("userId", 1, 30);
            await this.bidsService.AddBidAsync("anotherId", 1, 30);
            await this.bidsService.AddBidAsync("anotherId", 1, 70);
            await this.bidsService.AddBidAsync("anotherId", 2, 70);

            var bid = this.db.Bids.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "anotherId");

            Assert.Equal(100, bid.BidAmount);
        }

        [Fact]
        public async Task AddBidAsyncPlusPrice_ShouldAddNewBidPlusPrice()
        {
            await this.bidsService.AddBidAsyncPlusPrice("userId", 1, 20, 10);

            var bid = this.db.Bids.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(30, bid.BidAmount);
        }

        [Fact]
        public async Task AddBidToHistory_ShouldAddBidToExistingHistory()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistory("userId", 1, 40);
            await this.bidsService.AddBidToHistory("userId", 1, 60);

            var history = this.db.Histories.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(100, history.BidAmount);
        }

        [Fact]
        public async Task AddBidToHistory_ShouldAddNewBidHistory()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistory("userId", 1, 40);

            var history = this.db.Histories.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(40, history.BidAmount);
        }

        [Fact]
        public async Task AddBidToHistoryPlusPrice_ShouldAddBidToExistingHistory()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistoryPlusPrice("userId", 1, 40, 10);
            await this.bidsService.AddBidToHistoryPlusPrice("userId", 1, 50, 10);

            var history = this.db.Histories.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(100, history.BidAmount);
        }

        [Fact]
        public async Task AddBidToHistoryPlusPrice_ShouldAddBidNewHistory()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistoryPlusPrice("userId", 1, 40, 10);

            var history = this.db.Histories.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(50, history.BidAmount);
        }

        [Fact]
        public async Task GetSumBids_ShouldGetAuctionBidAmount()
        {
            await this.bidsService.AddBidAsync("userId", 1, 20);
            await this.bidsService.AddBidAsync("anotherId", 1, 80);
            await this.bidsService.AddBidAsync("anotherId", 2, 80);

            var sum = this.bidsService.GetSumBids(1);

            Assert.Equal(100, sum);
        }

        [Fact]
        public void GetDbUserBalance_ShouldReturnCurrentUserVirtualBalanceWithUserService()
        {
            var user = this.AddUser();
            var result = this.bidsService.GetDbUserBalance(user.Id);

            Assert.Equal(3000, result);
        }

        [Fact]
        public void GetDbUserStaticBalance_ShouldReturnCurrentUserBalanceWithUserService()
        {
            var user = this.AddUser();
            var result = this.bidsService.GetDbUserStaticBalance(user.Id);

            Assert.Equal(3000, result);
        }

        [Fact]
        public async Task ReturnBids_ShouldDeleteHistoryAfterReturnBidToUser()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistory("userId", 1, 40);
            await this.bidsService.AddBidToHistory("anotherId", 1, 60);
            await this.bidsService.ReturnBids("anotherId", 1);
            var history = this.db.Histories.Select(x => x.AuctionId == 1).Count();

            Assert.Equal(1, history);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateLastBidderToAuction()
        {
            var auction = this.AddAuction();
            var lastBidder = this.LastBidderView();

            await this.bidsService.UpdateAsync(1, lastBidder);

            Assert.Equal("anotherId@gmail.com", auction.LastBidder);
        }

        [Fact]
        public async Task GetMoneyFromDbUser_ShouldGoDownVirtualBalanceAtCurrentUser()
        {
            var user = this.AddUserFTW();

            await this.bidsService.GetMoneyFromDbUser(user.Id, 50);

            Assert.Equal(2950, user.VirtualBalance);
        }

        [Fact]
        public void GetUser_ShouldCreateNewLastUserBidViewModel()
        {
            var result = this.bidsService.GetUser("userId", "user@gmail.com");

            Assert.Equal("user@gmail.com", result.Email);
            Assert.Equal("userId", result.Id);
            Assert.Equal("LastUserBidViewModel", result.GetType().Name.ToString());
        }

        [Fact]
        public async Task GetUserBids_ShouldGetUserBidHistoryInPropertyBidAmount()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistory("userId", auction.Id, 40);
            await this.bidsService.AddBidToHistory("another", auction.Id, 40);
            await this.bidsService.AddBidToHistory("userId", auction.Id, 40);
            await this.bidsService.AddBidToHistory("userId", auction.Id, 60);

            var sum = this.bidsService.GetUserBids("userId", auction.Id);
            Assert.Equal(140, sum);
        }

        [Fact]
        public async Task GetUserBids_ShouldReturn0()
        {
            var auction = this.AddAuction();

            await this.bidsService.AddBidToHistory("userId", auction.Id, 40);
            await this.bidsService.AddBidToHistory("another", auction.Id, 40);
            await this.bidsService.AddBidToHistory("userId", auction.Id, 40);
            await this.bidsService.AddBidToHistory("userId", auction.Id, 60);

            var sum = this.bidsService.GetUserBids("userWithNoBids", auction.Id);
            Assert.Equal(0, sum);
        }

        [Fact]
        public void GetAuctionPrice_ShouldGetAuctionCurrentPrice()
        {
            var auction = this.AddAuction();
            var result = this.bidsService.GetAuctionPrice(auction.Id);

            Assert.Equal(10, result);
        }

        [Fact]
        public async Task GetAuctionPrice_ShouldGetAuctionCurrentPriceAfterBid()
        {
            var auction = this.AddAuction();
            await this.bidsService.AddBidToHistory("userId", auction.Id, 40);

            var result = this.bidsService.GetAuctionPrice(auction.Id);

            Assert.Equal(50, result);
        }

        [Fact]
        public void CheckForCorrectBid_ShouldReturnTrueIfBidIsCorrect()
        {
            var result = this.bidsService.CheckForCorrectBid(50);

            Assert.True(result);
        }

        [Fact]
        public void CheckForCorrectBid_ShouldReturnFalseIfBidIsIncorrect()
        {
            var result = this.bidsService.CheckForCorrectBid(3500);

            Assert.False(result);
        }

        [Fact]
        public void CanUserMakeBid_ShouldReturnTrueIfUserHaveEnoughBalance()
        {
            var user = this.AddUser();

            var result = this.bidsService.CanUserMakeBid(user.Id, 10);

            Assert.True(result);
        }

        [Fact]
        public void CanUserMakeBid_ShouldReturnFalseIfUserDoesntHaveEnoughBalance()
        {
            var user = this.AddUser();

            var result = this.bidsService.CanUserMakeBid(user.Id, 5000);

            Assert.False(result);
        }

        [Fact]
        public void AmIFirstBidder_ShouldReturnTrueIfIAmFirtBidderForThisAuction()
        {
            var auction = this.AddAuction();
            var result = this.bidsService.AmIFirstBidder(auction.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task AmIFirstBidder_ShouldReturnFalseIfIAmNotFirtBidderForThisAuction()
        {
            var auction = this.AddAuction();
            await this.bidsService.AddBidToHistoryPlusPrice("bidderId", auction.Id, 10, auction.CurrentPrice);

            var result = this.bidsService.AmIFirstBidder(auction.Id);

            Assert.False(result);
        }

        [Fact]
        public async Task AmILastBidder_ShouldReturnTrueIfLastUserIdInAuctionHistoryIsMine()
        {
            var auction = this.AddAuction();
            await this.bidsService.AddBidAsyncPlusPrice("bidderId", auction.Id, 20, auction.CurrentPrice);

            var result = this.bidsService.AmILastBidder("bidderId", auction.Id);

            Assert.False(result);
        }

        [Fact]
        public void AmILastBidder_ShouldReturnFalseIfAuctionDoesntHaveBidHistory()
        {
            var auction = this.AddAuction();

            var result = this.bidsService.AmILastBidder("bidderId", auction.Id);

            Assert.False(result);
        }

        [Fact]
        public async Task AmILastBidder_ShouldReturnFalseIfLastUserIdInAuctionHistoryIsNotMine()
        {
            var auction = this.AddAuction();
            await this.bidsService.AddBidAsyncPlusPrice("bidderId", auction.Id, 20, auction.CurrentPrice);

            var result = this.bidsService.AmILastBidder("mineId", auction.Id);

            Assert.False(result);
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
                VirtualBalance = 3000,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user;
        }

        private ApplicationUser AddUserFTW()
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

        private LastUserBidViewModel LastBidderView()
        {
            var lastBidder = new LastUserBidViewModel
            {
                Email = "anotherId@gmail.com",
                Id = "anotherId",
            };
            return lastBidder;
        }
    }
}
