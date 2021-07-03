namespace AuctionHouse.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Auctions;

    public class AuctionService : IAuctionService
    {
        private readonly IDeletableEntityRepository<Auction> auctionsRepository;

        public AuctionService(IDeletableEntityRepository<Auction> auctionsRepository)
        {
            this.auctionsRepository = auctionsRepository;
        }

        public async Task CreateAsync(CreateAuctionInputModel input)
        {
            var auction = new Auction()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                Timer = TimeSpan.FromDays(input.Timer),
                CategoryId = input.CategoryId,
            };

            await this.auctionsRepository.AddAsync(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }
    }
}
