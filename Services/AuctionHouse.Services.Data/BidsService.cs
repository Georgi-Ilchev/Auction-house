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

        public BidsService(IRepository<Bid> bidsRepository, IRepository<Auction> auctionsRepository)
        {
            this.bidsRepository = bidsRepository;
            this.auctionsRepository = auctionsRepository;
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
                    Timestamp = DateTime.UtcNow,
                    LastBidder = userId,
                };
                await this.bidsRepository.AddAsync(bid);
            }

            bid.BidAmount += price;
            bid.LastBidder = userId;

            await this.bidsRepository.SaveChangesAsync();
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
    }
}
