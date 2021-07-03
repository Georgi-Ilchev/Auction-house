﻿namespace AuctionHouse.Services.Data
{
    using System.Linq;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Data.Models;
    using AuctionHouse.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categories;
        private readonly IDeletableEntityRepository<Auction> auctions;

        public GetCountsService(
            IDeletableEntityRepository<Category> categories,
            IDeletableEntityRepository<Auction> auctions)
        {
            this.categories = categories;
            this.auctions = auctions;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                AuctionsCount = this.auctions.All().Count(),
                CategoriesCount = this.categories.All().Count(),
            };

            return data;
        }
    }
}
