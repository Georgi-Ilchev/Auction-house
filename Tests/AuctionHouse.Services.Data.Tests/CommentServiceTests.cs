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
    using AuctionHouse.Web.ViewModels.Comments;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CommentServiceTests
    {
        private EfDeletableEntityRepository<Comment> commentRepository;
        private DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private ApplicationDbContext db;
        private ICommentService commentService;

        public CommentServiceTests()
        {
            this.optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            this.db = new ApplicationDbContext(this.optionsBuilder.Options);
            this.commentRepository = new EfDeletableEntityRepository<Comment>(this.db);
            this.commentService = new CommentService(this.commentRepository);

            AutoMapperConfig.RegisterMappings(typeof(CommentViewModel).Assembly, typeof(Comment).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetType().Assembly);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateComment()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            var comment = this.db.Comments.FirstOrDefault(x => x.UserId == "userId" && x.Content == "content");

            Assert.Equal("content", comment.Content);
            Assert.Equal("userId", comment.UserId);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateCommentCorrect()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            await this.commentService.CreateAsync(1, "userId", "other content");
            var count = this.db.Comments.Where(x => x.AuctionId == 1).Count();

            Assert.Equal(2, count);
        }

        [Fact]
        public async Task Delete_ShouldDeleteComment()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            await this.commentService.CreateAsync(1, "userId", "comment text");
            await this.commentService.Delete(1);

            var count = this.db.Comments.Where(x => x.AuctionId == 1).Count();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task Delete_ShouldDeleteCommentCorrect()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            await this.commentService.CreateAsync(1, "userId", "comment text");
            await this.commentService.Delete(2);

            var comment = this.db.Comments.All(x => x.AuctionId == 1 && x.UserId == "userId" && x.Content == "content");

            Assert.True(comment);
        }

        [Fact]
        public async Task GetAll_ShouldGetAllCommentsByAuctionIdCount()
        {
            var user = this.AddUser();

            await this.commentService.CreateAsync(1, user.Id, "content");
            await this.commentService.CreateAsync(2, user.Id, "otherContent");

            var result = this.commentService.GetAll(1, 1, 8).Count();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetAll_ShouldGetAllCommentsByAuctionId()
        {
            var user = this.AddUser();

            await this.commentService.CreateAsync(1, user.Id, "content");
            await this.commentService.CreateAsync(2, user.Id, "otherContent");

            var result = this.commentService.GetAll(1, 1, 8);

            Assert.Contains(result, c => c.Content == "content" && c.AuctionId == 1);
        }

        [Fact]
        public async Task GetCommentsCount_ShouldGetCommentsCountForAuctionByAuctionId()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            await this.commentService.CreateAsync(1, "userId", "other content");
            await this.commentService.CreateAsync(1, "anotherId", "other content btw");
            await this.commentService.CreateAsync(2, "anotherId", "content btw");
            var count = this.commentService.GetCommentsCount(1);

            Assert.Equal(3, count);
        }

        [Fact]
        public async Task OwnedByUser_ShouldReturnTrueIfUserIsCreatingCurrentComment()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            await this.commentService.CreateAsync(1, "userId", "other content");
            await this.commentService.CreateAsync(1, "anotherId", "other content btw");
            await this.commentService.CreateAsync(2, "anotherId", "content btw");

            var result = this.commentService.OwnedByUser("anotherId", 3);

            Assert.True(result);
        }

        [Fact]
        public async Task OwnedByUser_ShouldReturnFalseIfUserIsNotOwner()
        {
            await this.commentService.CreateAsync(1, "userId", "content");
            await this.commentService.CreateAsync(1, "userId", "other content");
            await this.commentService.CreateAsync(1, "anotherId", "other content btw");
            await this.commentService.CreateAsync(2, "anotherId", "content btw");

            var result = this.commentService.OwnedByUser("anotherId", 1);

            Assert.False(result);
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
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user;
        }
    }
}
