using AuctionHouse.Data.Common.Repositories;
using AuctionHouse.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuctionHouse.Services.Data.Tests
{
    public class CategoriesServiceTests
    {
        private readonly Mock<IDeletableEntityRepository<Category>> categoryRepository;

        public CategoriesServiceTests()
        {
            this.categoryRepository = new Mock<IDeletableEntityRepository<Category>>();
        }

        [Fact]
        public void GetAllAsKeyValuePairs_ShouldReturn_CategoriesCount()
        {
            this.categoryRepository.Setup(x => x.AllAsNoTracking())
                .Returns(new List<Category>
                {
                    new Category
                    {
                        Name = "Travel",
                    },
                    new Category
                    {
                        Name = "Unique",
                    },

                }.AsQueryable());

            var service = new CategoriesService(this.categoryRepository.Object);

            var expected = 2;
            var actual = service.GetAllAsKeyValuePairs().ToList().Count();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllAsKeyValuePairs_ShouldReturn_CorrectCategory()
        {
            this.categoryRepository.Setup(x => x.AllAsNoTracking())
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

            var service = new CategoriesService(this.categoryRepository.Object);

            var expectedKey = "1";
            var expectedName = "Travel";

            var actual = service.GetAllAsKeyValuePairs().ToList();

            Assert.Equal(expectedKey, actual[0].Key);
            Assert.Equal(expectedName, actual[0].Value);
        }
    }
}
