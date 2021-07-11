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
        private readonly IRepository<ApplicationUser> usersRepository;

        public BidsService(IRepository<Bid> bidsRepository, IRepository<ApplicationUser> usersRepository)
        {
            this.bidsRepository = bidsRepository;
            this.usersRepository = usersRepository;
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

        public LastUserBidViewModel GetUser(string userId, string email)
        {
            var user = new LastUserBidViewModel
            {
                Id = userId,
                Email = email,
            };

            //var user = this.usersRepository.All()
            //    .FirstOrDefault(x => x.Id == userId && x.Email == email);

            return user;
        }
    }
}
