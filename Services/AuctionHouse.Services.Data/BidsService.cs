namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Bids;

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
            bid.LastBidder = userId;

            await this.bidsRepository.SaveChangesAsync();
        }

        public async Task AddBidToHistory(string userId, int auctionId, decimal price)
        {
            var auction = this.auctionsRepository.All()
                .FirstOrDefault(x => x.Id == auctionId && x.UserId == userId);

            var history = this.historiesRepository.All()
                .FirstOrDefault(x => x.Id == auctionId && x.UserId == userId);

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
            }

            await this.historiesRepository.SaveChangesAsync();
        }

        public decimal GetSumBids(int auctionId)
        {
            return this.bidsRepository.All()
                .Where(x => x.AuctionId == auctionId)
                .Sum(x => x.BidAmount);
        }

        public async Task UpdateAsync(int id, LastUserBidViewModel input)
        {
            var auctions = this.auctionsRepository.All().FirstOrDefault(x => x.Id == id);
            auctions.LastBidder = input.Email;

            await this.auctionsRepository.SaveChangesAsync();
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

        public async Task GetMoneyFromDbUser(string userId, decimal amount)
        {
            await this.userService.UpdateDbUserVirtualBalance(userId, amount);
        }

        public decimal GetDbUserBalance(string userId)
        {
            var userBalance = this.userService.GetVirtualUserBalance(userId);

            return userBalance;
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
    }
}
