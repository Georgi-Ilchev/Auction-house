using AuctionHouse.Data;
using AuctionHouse.Data.Models;
using AuctionHouse.Data.Repositories;
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
        public async Task AddBidToHistory_ShouldAddNewBidHistory()
        {
            //await this.bidsService.AddBidAsync("userId", 1, 20);
            //await this.bidsService.AddBidAsync("userId", 1, 20);
           

            await this.bidsService.AddBidToHistory("userId", 1, 40);

            //var history = new History
            //{
            //    UserId = "userId",
            //    AuctionId = 1,
            //    BidAmount = 20,
            //};

            //await this.db.Histories.AddAsync(history);
            //await this.db.SaveChangesAsync();

            var history1 = this.db.Histories.FirstOrDefault(x => x.AuctionId == 1 && x.UserId == "userId");

            Assert.Equal(40, history1.BidAmount);
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
    }
}
