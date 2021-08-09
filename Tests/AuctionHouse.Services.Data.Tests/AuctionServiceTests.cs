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

namespace AuctionHouse.Services.Data.Tests
{
    public class AuctionServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Auction>> auctionRepository;
        private readonly Mock<IDeletableEntityRepository<Category>> categoryRepository;

        public AuctionServiceTests()
        {
            this.auctionRepository = new Mock<IDeletableEntityRepository<Auction>>();
            this.categoryRepository = new Mock<IDeletableEntityRepository<Category>>();

            AutoMapperConfig.RegisterMappings(typeof(ListAuctionViewModel).Assembly, typeof(Auction).Assembly);
        }

        [Fact]
        public async Task GetAll_ShouldReturnEmpty_WhenAuctionsDoesntExist()
        {
            var service = new AuctionService(this.auctionRepository.Object, this.categoryRepository.Object);

            var auctions = await service.GetAll<ListAuctionViewModel>(1, 8);

            Assert.Empty(auctions);
        }

        //[Fact]
        //public async Task GetAll_ShouldReturnAuctions()
        //{
        //    this.auctionRepository.Setup(x => x.AllAsNoTracking())
        //        .Returns(new List<Auction>
        //        {
        //            new Auction
        //            {
        //                Name = "auction",
        //            },
        //        }.AsQueryable());

        //    var service = new AuctionService(this.auctionRepository.Object, this.categoryRepository.Object);

        //    var auctions = await service.GetAll<ListAuctionViewModel>(1, 8);

        //    Assert.Equal(1, auctions)
        //}

        [Fact]
        public void GetWeeklyAuctions_ShouldGetOnlyWeeklyAuctions()
        {
            this.auctionRepository.Setup(x => x.AllAsNoTracking())
                .Returns(new List<Auction>
                {
                    new Auction
                    {
                        Id = 1,
                        Name = "auction",
                        IsAuctionOfTheWeek = false,
                    },
                    new Auction
                    {
                        Id = 2,
                        Name = "another auction",
                        IsAuctionOfTheWeek = true,
                    },
                }.AsQueryable());

            var service = new AuctionService(this.auctionRepository.Object, this.categoryRepository.Object);
            //var actual = service.GetWeeklyAuctions();
        }
    }
}
