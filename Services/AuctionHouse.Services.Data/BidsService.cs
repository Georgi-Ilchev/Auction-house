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

        public async Task SetBidAsync(string userId, int auctionId, decimal price)
        {
            var bid = this.bidsRepository.All()
                .FirstOrDefault(x => x.AuctionId == auctionId && x.UserId == userId);

            if (bid == null)
            {
                bid = new Bid
                {
                    UserId = userId,
                    AuctionId = auctionId,
                };

                await this.bidsRepository.AddAsync(bid);
            }

            bid.Bidding = price;

            await this.bidsRepository.SaveChangesAsync();
        }
    }
}
