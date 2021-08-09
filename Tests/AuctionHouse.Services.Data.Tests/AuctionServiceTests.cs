using AuctionHouse.Data;
using AuctionHouse.Data.Common.Repositories;
using AuctionHouse.Data.Models;
using AuctionHouse.Data.Repositories;
using AuctionHouse.Web.ViewModels.Auctions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AuctionHouse.Services.Mapping;
using AuctionHouse.Web.ViewModels;

namespace AuctionHouse.Services.Data.Tests
{
    public class AuctionServiceTests
    {
        private ApplicationDbContext db;
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private EfDeletableEntityRepository<Auction> auctionRepository;
        private EfDeletableEntityRepository<Category> categoryRepository;
        private IAuctionService auctionService;

        public AuctionServiceTests()
        {
            this.optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.db = new ApplicationDbContext(this.optionsBuilder.Options);

            this.auctionRepository = new EfDeletableEntityRepository<Auction>(this.db);
            this.categoryRepository = new EfDeletableEntityRepository<Category>(this.db);

            this.auctionService = new AuctionService(this.auctionRepository, this.categoryRepository);

            AutoMapperConfig.RegisterMappings(typeof(ListAuctionViewModel).Assembly, typeof(Auction).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetType().Assembly);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateAuction()
        {
            this.categoryRepository.AddAsync(new Category { Name = "Travel", Id = 1 });

            var viewAuction = new CreateAuctionInputModel()
            {
                Name = "new auction",
                Description = "random description",
                ActiveDays = 2,
                CategoryId = 1,
            };

            await this.auctionService.CreateAsync(viewAuction, "userId", "imagePath");

            var auction = this.db.Auctions.FirstOrDefault(x => x.UserId == "userId" && x.Name == "new auction");

            Assert.Equal("new auction", auction.Name);
            Assert.Equal("random description", auction.UserId);
        }

        [Fact]
        public async Task GetAuctionsCount_ShouldGetAuctionsCount()
        {
            this.auctionService.GetAuctionsCount();
        }
    }
}
