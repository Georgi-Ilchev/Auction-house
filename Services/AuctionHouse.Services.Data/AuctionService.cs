namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AuctionHouse.Web.ViewModels.Auctions;

    public class AuctionService : IAuctionService
    {
        private readonly IDeletableEntityRepository<Auction> auctionsRepository;

        public AuctionService(IDeletableEntityRepository<Auction> auctionsRepository)
        {
            this.auctionsRepository = auctionsRepository;
        }

        public async Task CreateAsync(CreateAuctionInputModel input, string userId)
        {
            var auction = new Auction()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                Timer = TimeSpan.FromDays(input.Timer),
                CategoryId = input.CategoryId,
                UserId = userId,
            };

            await this.auctionsRepository.AddAsync(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return auctions;
        }
    }
}
