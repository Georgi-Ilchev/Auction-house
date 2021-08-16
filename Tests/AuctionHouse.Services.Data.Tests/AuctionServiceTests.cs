namespace AuctionHouse.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Data.Repositories;
    using AuctionHouse.Services.Mapping;
    using AuctionHouse.Web.ViewModels;
    using AuctionHouse.Web.ViewModels.Auctions;
    using AuctionHouse.Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

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
            AutoMapperConfig.RegisterMappings(typeof(ListAuctionsViewModel).Assembly, typeof(Auction).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(IndexPageAuctionViewModel).Assembly, typeof(Auction).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetType().Assembly);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllAuctions()
        {
            await this.auctionRepository.AddAsync(this.AddAuction());
            this.db.ChangeTracker.Clear();
            await this.auctionRepository.AddAsync(this.AddAnotherAuction());
            this.db.ChangeTracker.Clear();
            await this.auctionRepository.SaveChangesAsync();
            var result = await this.auctionService.GetAll<ListAuctionViewModel>(1);

            Assert.Contains(result, c => c.Name == "old saxophone" && c.Price == 10);
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
        public void GetAuctionsCount_ShouldGetAuctionsCount()
        {
            this.AddAuction();
            var result = this.auctionService.GetAuctionsCount();

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetAuctionsCount_ShouldReturn0IfThereIsNoAuction()
        {
            var result = this.auctionService.GetAuctionsCount();

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetAuctionsCountByCategory_ShouldGetAuctionsCountByCategory()
        {
            this.AddAuction();
            var result = this.auctionService.GetAuctionsCountByCategory(1);

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetAuctionsCountByCategory_ShouldReturn0IfThereIsNoAuctionByCurrentCategoryId()
        {
            this.AddAuction();
            var result = this.auctionService.GetAuctionsCountByCategory(2);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetUserAuctionsCount_ShouldGetAuctionsCountByCurrentUser()
        {
            this.AddAuction();
            var result = this.auctionService.GetUserAuctionsCount("userId");

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetUserAuctionsCount_ShouldReturn0IfThereIsNoAuctionByCurrentUserId()
        {
            this.AddAuction();
            var result = this.auctionService.GetUserAuctionsCount("anotherId");

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetUserPurchasesCount_ShouldGetAuctionsCountByUserPurchasesByEmail()
        {
            this.AddAnotherAuctionWithLastBidder();
            var result = this.auctionService.GetUserPurchasesCount("lastBidder@gmail.com");

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetUserPurchasesCount_ShouldReturn0IfAuctionIsPaidIsFalse()
        {
            this.AddAuction();
            var result = this.auctionService.GetUserPurchasesCount("lastBidder@gmail.com");

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetUserPurchasesCount_ShouldReturn0IfUserDoesntHavePurchases()
        {
            this.AddAnotherAuctionWithLastBidder();
            var result = this.auctionService.GetUserPurchasesCount("invalid@gmail.com");

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetUserSalesCount_ShouldGetAuctionsCountByUserSalesById()
        {
            this.AddAnotherAuctionWithLastBidder();
            var result = this.auctionService.GetUserSalesCount("anotherId");

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetUserSalesCount_ShouldReturn0IfCurrentUserDoesntHaveSales()
        {
            this.AddAnotherAuctionWithLastBidder();
            var result = this.auctionService.GetUserSalesCount("noSalesId");

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetUserSalesCount_ShouldReturn0IfAuctionIsPaidIsFalse()
        {
            this.AddAuction();
            var result = this.auctionService.GetUserSalesCount("userId");

            Assert.Equal(0, result);
        }

        [Fact]
        public void OwnedByUser_ShouldReturnTrueIfUserIsOwnerByAuctionId()
        {
            this.AddAuction();
            var result = this.auctionService.OwnedByUser("userId", 1);

            Assert.True(result);
        }

        [Fact]
        public void OwnedByUser_ShouldReturnFalseIfUserIsNotOwnerByAuctionId()
        {
            this.AddAuction();
            var result = this.auctionService.OwnedByUser("anotherId", 1);

            Assert.False(result);
        }

        [Fact]
        public void IsAuctionExisting_ShouldReturnTrueIfAuctionExisting()
        {
            this.AddAuction();
            var result = this.auctionService.IsAuctionExisting(1);

            Assert.True(result);
        }

        [Fact]
        public void IsAuctionExisting_ShouldReturnFalseIfAuctionDoesntExisting()
        {
            this.AddAuction();
            var result = this.auctionService.IsAuctionExisting(2);

            Assert.False(result);
        }

        [Fact]
        public void IsThereLastBidder_ShouldReturnTrueIfThereIsLastBidder()
        {
            this.AddAnotherAuctionWithLastBidder();
            var result = this.auctionService.IsThereLastBidder(2);

            Assert.True(result);
        }

        [Fact]
        public void IsThereLastBidder_ShouldReturnFalseIfTheresNotLastBidder()
        {
            this.AddAuction();
            var result = this.auctionService.IsThereLastBidder(1);

            Assert.False(result);
        }

        [Fact]
        public void GetWeeklyAuctions_ShouldReturnListOfWeeklyAuctions()
        {
            this.AddAnotherAuction();
            //var result = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.IsAuctionOfTheWeek == true).Id;
            var result = this.auctionService.GetWeeklyAuctions<IndexPageAuctionViewModel>().Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetById_ShouldGetCurrentAuctionById()
        {
            // todo
        }

        [Fact]
        public async Task PromoteAuctionOfWeek_ShouldPromoteCurrentAuctonToWeekly()
        {
            this.AddAuction();
            var promoteEnd = DateTime.UtcNow.ToLocalTime().AddDays(2);

            await this.auctionService.PromoteAuctionOfWeek(promoteEnd, 1);

            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 1);

            Assert.True(auction.IsAuctionOfTheWeek);
            Assert.Equal(promoteEnd, auction.EndPromoted);
        }

        [Fact]
        public async Task UnPromoteAuctionOfWeek_ShouldUnPromoteCurrentAuctionFromWeekly()
        {
            this.AddAnotherAuction();

            await this.auctionService.UnPromoteAuctionOfWeek(2);

            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 2);

            Assert.False(auction.IsAuctionOfTheWeek);
            Assert.Null(auction.StartPromoted);
            Assert.Null(auction.EndPromoted);
        }

        [Fact]
        public async Task Delete_ShouldDeleteCurrentAuctionById()
        {
            this.AddAuction();
            this.AddAnotherAuction();

            await this.auctionService.Delete(1);

            var result = this.auctionRepository.AllAsNoTracking().Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Delete_ShouldDeleteCurrentAuctionByIdCorrect()
        {
            this.AddAuction();
            this.AddAnotherAuction();

            await this.auctionService.Delete(1);

            var result = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 1);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateDbAuction_ShouldUpdateAuctionActiveToFalse()
        {
            this.AddAuctionForUpdate();
            this.db.ChangeTracker.Clear();
            await this.auctionService.UpdateDbAuction(4);

            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 4);

            Assert.False(auction.IsActive);
        }

        [Fact]
        public async Task UpdateDbAuction_ShouldUpdateAuctionIsSoldToTrue()
        {
            this.AddAuctionForUpdate();
            this.db.ChangeTracker.Clear();
            await this.auctionService.UpdateDbAuction(4);

            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 4);

            Assert.True(auction.IsSold);
        }

        [Fact]
        public async Task UpdateDbAuction_ShouldUpdateAuctionWeeklyStatusToFalse()
        {
            this.AddAuctionForUpdate();
            this.db.ChangeTracker.Clear();
            await this.auctionService.UpdateDbAuction(4);

            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 4);

            Assert.Null(auction.StartPromoted);
            Assert.Null(auction.EndPromoted);
            Assert.False(auction.IsAuctionOfTheWeek);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateAuctionByInput()
        {
            this.AddCategory();
            this.db.ChangeTracker.Clear();
            this.AddAnotherCategory();
            this.AddAuctionForUpdate();

            await this.auctionService.UpdateAsync(4, this.AddEditModel());

            var auction = this.auctionRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == 4);

            Assert.Equal(2, auction.CategoryId);
        }

        [Fact]
        public async Task GetUserAuctions_ShouldReturnCurrentUsersAuctionsById()
        {
            this.AddAuction();

            var result = this.auctionService.GetUserAuctions<ListAuctionsViewModel>("userId", 1);
            var auctions = result as ListAuctionsViewModel[] ?? result.ToArray();

            Assert.Equal(null, auctions);
        }

        private Auction AddAuction()
        {
            var auction = new Auction()
            {
                Id = 1,
                Name = "old saxophone",
                Description = "description",
                Price = 10,
                CurrentPrice = 10,
                ActiveTo = DateTime.UtcNow.AddDays(2),
                User = this.AddUser(),
                CategoryId = 1,
                IsPaid = false,
            };

            this.db.Auctions.Add(auction);
            this.db.SaveChanges();

            return auction;
        }

        private Auction AddAnotherAuction()
        {
            var auction = new Auction()
            {
                Id = 2,
                Name = "new saxophone",
                Description = "description",
                Price = 10,
                CurrentPrice = 10,
                ActiveTo = DateTime.UtcNow.AddDays(2),
                User = this.AddAnotherUser(),
                CategoryId = 1,
                IsPaid = false,
                IsAuctionOfTheWeek = true,
            };

            this.db.Auctions.Add(auction);
            this.db.SaveChanges();

            return auction;
        }

        private Auction AddAnotherAuctionWithLastBidder()
        {
            var auction = new Auction()
            {
                Id = 2,
                Name = "new saxophone",
                Description = "description",
                Price = 10,
                CurrentPrice = 10,
                ActiveTo = DateTime.UtcNow.AddDays(2),
                User = this.AddAnotherUser(),
                CategoryId = 1,
                IsPaid = true,
                IsAuctionOfTheWeek = true,
                LastBidder = "lastBidder@gmail.com",
            };

            this.db.Auctions.Add(auction);
            this.db.SaveChanges();

            return auction;
        }

        private Auction AddAuctionForUpdate()
        {
            var auction = new Auction()
            {
                Id = 4,
                Name = "new saxophone",
                Description = "description",
                Price = 10,
                CurrentPrice = 10,
                ActiveTo = DateTime.UtcNow,
                User = this.AddAnotherUser(),
                CategoryId = 1,
                IsPaid = false,
                IsAuctionOfTheWeek = true,
                IsActive = true,
                IsSold = false,
                EndPromoted = DateTime.UtcNow,
                LastBidder = "lastBidder@gmail.com",
            };

            this.db.Auctions.Add(auction);
            this.db.SaveChanges();

            return auction;
        }

        private ApplicationUser AddUser()
        {
            var user = new ApplicationUser()
            {
                Id = "userId",
                Email = "user@gmail.com",
                IsDeleted = false,
                PasswordHash = "UnhashedPass2021",
                UserName = "user@gmail.com",
                CreatedOn = DateTime.UtcNow,
                NormalizedUserName = "USER@GMAIL.COM",
                NormalizedEmail = "USER@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = "SecurityStamp",
                ConcurrencyStamp = "ConcurrencyStamp",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Balance = 3000,
                VirtualBalance = 2000,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user;
        }

        private ApplicationUser AddAnotherUser()
        {
            var user = new ApplicationUser()
            {
                Id = "anotherId",
                Email = "another@gmail.com",
                IsDeleted = false,
                PasswordHash = "UnhashedPass2021",
                UserName = "another@gmail.com",
                CreatedOn = DateTime.UtcNow,
                NormalizedUserName = "ANOTHER@GMAIL.COM",
                NormalizedEmail = "ANOTHER@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = "SecurityStamp",
                ConcurrencyStamp = "ConcurrencyStamp",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                Balance = 3000,
                VirtualBalance = 2000,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user;
        }

        private EditAuctionInputModel AddEditModel()
        {
            var model = new EditAuctionInputModel()
            {
                Id = 4,
                Description = "new description",
                Name = "new name for auctionId4",
                CategoryId = 2,
            };

            return model;
        }

        private Category AddCategory()
        {
            var category = new Category()
            {
                Id = 2,
                Name = "new category",
            };

            return category;
        }

        private Category AddAnotherCategory()
        {
            var category = new Category()
            {
                Id = 1,
                Name = "neww category",
            };

            return category;
        }
    }
}
