namespace AuctionHouse.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Data.Models;
    using Moq;
    using Xunit;

    public class GetCountsServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Category>> categoryRepository;
        private readonly Mock<IDeletableEntityRepository<Auction>> auctionsRepository;

        public GetCountsServiceTests()
        {
            this.categoryRepository = new Mock<IDeletableEntityRepository<Category>>();
            this.auctionsRepository = new Mock<IDeletableEntityRepository<Auction>>();
        }

        [Fact]
        public void GetCounts_ShouldReturn_CategoriesCount()
        {
            this.categoryRepository.Setup(x => x.All())
                .Returns(new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Travel",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Unique",
                    },
                }.AsQueryable());

            var service = new GetCountsService(this.categoryRepository.Object, this.auctionsRepository.Object);
            var actual = service.GetCounts().CategoriesCount;

            Assert.Equal(2, actual);
        }

        [Fact]
        public void GetCounts_ShouldReturn_AuctionsCount()
        {
            this.auctionsRepository.Setup(x => x.All())
                .Returns(new List<Auction>
                {
                    new Auction
                    {
                        Id = 1,
                        Name = "Auction1",
                    },
                    new Auction
                    {
                        Id = 2,
                        Name = "Auction2",
                    },
                }.AsQueryable());

            var service = new GetCountsService(this.categoryRepository.Object, this.auctionsRepository.Object);
            var actual = service.GetCounts().AuctionsCount;

            Assert.Equal(2, actual);
        }

        [Fact]
        public void GetCounts_ShouldReturn_AuctionsCount_WhereIsPaidEqualFalse()
        {
            this.auctionsRepository.Setup(x => x.All())
                .Returns(new List<Auction>
                {
                    new Auction
                    {
                        Id = 1,
                        Name = "Auction1",
                        IsPaid = false,
                    },
                    new Auction
                    {
                        Id = 2,
                        Name = "Auction2",
                        IsPaid = true,
                    },
                }.AsQueryable());

            var service = new GetCountsService(this.categoryRepository.Object, this.auctionsRepository.Object);
            var actual = service.GetCounts().AuctionsCount;

            Assert.Equal(1, actual);
        }

        [Fact]
        public void GetCounts_ShouldReturn_CorrectData()
        {
            var statisticsServiceMock = new Mock<IGetCountsService>();
            statisticsServiceMock.Setup(x => x.GetCounts())
                    .Returns(new CountsDto
                    {
                        AuctionsCount = 4,
                        CategoriesCount = 10,
                    });

            var auctions = statisticsServiceMock.Object.GetCounts().AuctionsCount;
            var categories = statisticsServiceMock.Object.GetCounts().CategoriesCount;

            Assert.Equal(4, auctions);
            Assert.Equal(10, categories);
        }
    }
}
