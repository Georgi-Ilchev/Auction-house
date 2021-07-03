namespace AuctionHouse.Services.Data
{
    using System.Linq;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categories;
        private readonly IDeletableEntityRepository<Image> images;
        private readonly IDeletableEntityRepository<Auction> auctions;

        public GetCountsService(
            IDeletableEntityRepository<Category> categories,
            IDeletableEntityRepository<Image> images,
            IDeletableEntityRepository<Auction> auctions)
        {
            this.categories = categories;
            this.images = images;
            this.auctions = auctions;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                AuctionsCount = this.auctions.All().Count(),
                CategoriesCount = this.categories.All().Count(),
            };

            return data;
        }
    }
}
