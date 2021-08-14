namespace AuctionHouse.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Bids;
    using Microsoft.EntityFrameworkCore;

    public class BidsService : IBidsService
    {
        private readonly IRepository<Bid> bidsRepository;
        private readonly IRepository<Auction> auctionsRepository;
        private readonly IRepository<History> historiesRepository;
        private readonly IUserService userService;
        private readonly int[] bids = new[] { 10, 20, 50, 100, 200, 300, 500, 1000, 3000, 5000 };

        public BidsService(
            IRepository<Bid> bidsRepository,
            IRepository<Auction> auctionsRepository,
            IRepository<History> historiesRepository,
            IUserService userService)
        {
            this.bidsRepository = bidsRepository;
            this.auctionsRepository = auctionsRepository;
            this.historiesRepository = historiesRepository;
            this.userService = userService;
        }

        public async Task AddBidAsync(string userId, int auctionId, decimal price)
        {
            var bid = this.bidsRepository.All()
                .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId == userId);

            if (bid == null)
            {
                bid = new Bid
                {
                    UserId = userId,
                    AuctionId = auctionId,
                    LastBidder = userId,
                };

                await this.bidsRepository.AddAsync(bid);
            }

            bid.BidAmount += price;

            await this.bidsRepository.SaveChangesAsync();
        }

        public async Task AddBidAsyncPlusPrice(string userId, int auctionId, decimal price, decimal auctionPrice)
        {
            var bid = this.bidsRepository.All()
                .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId == userId);

            if (bid == null)
            {
                bid = new Bid
                {
                    UserId = userId,
                    AuctionId = auctionId,
                    LastBidder = userId,
                };

                await this.bidsRepository.AddAsync(bid);
            }

            bid.BidAmount += price + auctionPrice;

            await this.bidsRepository.SaveChangesAsync();
        }

        public async Task AddBidToHistory(string userId, int auctionId, decimal price)
        {
            var auction = this.auctionsRepository.All()
                .Include(x => x.Histories)
                .FirstOrDefault(x => x.Id == auctionId);

            var history = this.historiesRepository.All()
                .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId == userId);

            if (history == null)
            {
                history = new History
                {
                    UserId = userId,
                    AuctionId = auctionId,
                    BidAmount = price,
                };

                await this.historiesRepository.AddAsync(history);

                auction.Histories.Add(history);
                auction.CurrentPrice += price;
            }
            else
            {
                history.BidAmount += price;
                auction.CurrentPrice += price;
            }

            await this.historiesRepository.SaveChangesAsync();
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task AddBidToHistoryPlusPrice(string userId, int auctionId, decimal price, decimal auctionPrice)
        {
            var auction = this.auctionsRepository.All()
                .Include(x => x.Histories)
                .FirstOrDefault(x => x.Id == auctionId);

            var history = this.historiesRepository.All()
                .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId == userId);

            if (history == null)
            {
                history = new History
                {
                    UserId = userId,
                    AuctionId = auctionId,
                    BidAmount = price + auctionPrice,
                };

                await this.historiesRepository.AddAsync(history);

                auction.Histories.Add(history);
                auction.CurrentPrice += price;
            }
            else
            {
                history.BidAmount += price;
                auction.CurrentPrice += price;
            }

            await this.historiesRepository.SaveChangesAsync();
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task ReturnBids(string userId, int auctionId)
        {
            var auction = this.auctionsRepository.All()
                .Include(x => x.Histories)
                .FirstOrDefault(x => x.Id == auctionId);

            var auctionHistories = auction.Histories.Count();

            if (auctionHistories == 2)
            {
                var history = this.historiesRepository.All()
                    .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId != userId);

                var amountToReturn = history.BidAmount;
                var giveMeTheMoneyId = history.UserId;

                auction.Histories.Remove(history);
                this.historiesRepository.Delete(history);

                await this.userService.UpdateReturningBids(giveMeTheMoneyId, amountToReturn);
                await this.historiesRepository.SaveChangesAsync();
                await this.auctionsRepository.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, LastUserBidViewModel input)
        {
            var auctions = this.auctionsRepository.All().FirstOrDefault(x => x.Id == id);
            auctions.LastBidder = input.Email;

            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task GetMoneyFromDbUser(string userId, decimal amount)
        {
            await this.userService.UpdateDbUserVirtualBalance(userId, amount);
        }

        public LastUserBidViewModel GetUser(string userId, string email)
        {
            var user = new LastUserBidViewModel
            {
                Id = userId,
                Email = email,
            };

            return user;
        }

        public decimal GetSumBids(int auctionId)
        {
            return this.bidsRepository.All()
                .Where(x => x.AuctionId == auctionId)
                .Sum(x => x.BidAmount);
        }

        public decimal GetDbUserBalance(string userId)
        {
            var userBalance = this.userService.GetVirtualUserBalance(userId);

            return userBalance;
        }

        public decimal GetDbUserStaticBalance(string userId)
        {
            var userBalance = this.userService.GetUserBalance(userId);

            return userBalance;
        }

        public decimal GetUserBids(string userId, int auctionId)
        {
            var history = this.historiesRepository.All()
                 .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId == userId);

            var sum = 0.0m;

            if (history != null)
            {
                sum = history.BidAmount;
            }

            return sum;
        }

        public decimal GetAuctionPrice(int auctionId)
        {
            var auctionPrice = this.auctionsRepository.All()
                .FirstOrDefault(x => x.Id == auctionId).CurrentPrice;

            return auctionPrice;
        }

        public bool CheckForCorrectBid(decimal bid)
        {
            for (int i = 0; i < this.bids.Length; i++)
            {
                var currentBid = this.bids[i];

                if (currentBid == bid)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanUserMakeBid(string userId, decimal bid)
        {
            var balance = this.GetDbUserBalance(userId);

            if (balance - bid < 0)
            {
                return false;
            }

            return true;
        }

        public bool AmILastBidder(string userId, int auctionId)
        {
            if (this.historiesRepository.All().FirstOrDefault(x => x.AuctionId == auctionId) == null)
            {
                return false;
            }

            var lastBidder = this.historiesRepository.All()
                .Where(x => x.AuctionId == auctionId)
                .OrderByDescending(x => x.CreatedOn).FirstOrDefault().UserId;

            if (lastBidder == userId)
            {
                return true;
            }

            return false;
        }

        public bool AmIFirstBidder(int auctionId)
        {
            var count = this.historiesRepository.All().Where(x => x.AuctionId == auctionId).Count();

            if (count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
