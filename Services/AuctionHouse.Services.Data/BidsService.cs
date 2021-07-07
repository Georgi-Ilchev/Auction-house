namespace AuctionHouse.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;

    public class BidsService : IBidsService
    {
        private readonly IRepository<Bid> bidsRepository;

        public BidsService(IRepository<Bid> bidsRepository)
        {
            this.bidsRepository = bidsRepository;
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
                    //BidAmount = price,
                };
                await this.bidsRepository.AddAsync(bid);
            }

            bid.BidAmount += price;

            await this.bidsRepository.SaveChangesAsync();
        }

        public decimal GetSumBids(int auctionId)
        {
            return this.bidsRepository.All()
                .Where(x => x.AuctionId == auctionId)
                .Sum(x => x.BidAmount);
        }
    }
}
