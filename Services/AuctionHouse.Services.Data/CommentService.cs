namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Web.ViewModels.Comments;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task CreateAsync(int auctionId, string userId, string content)
        {
            var comment = new Comment
            {
                Content = content,
                UserId = userId,
                AuctionId = auctionId,
                //CreatedOn = DateTime.UtcNow.ToLocalTime(),
                //PostedOn = DateTime.UtcNow.ToLocalTime(),
                CreatedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time")),
                PostedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time")),
                //CreatedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local),
                //PostedOn = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local),
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task Delete(int commentId)
        {
            var comment = this.commentsRepository.All().FirstOrDefault(a => a.Id == commentId);

            this.commentsRepository.Delete(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public IEnumerable<CommentViewModel> GetAll(int auctionId, int page, int itemsPerPage = 8)
        {
            var comments = this.commentsRepository.All()
                .AsQueryable()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.AuctionId == auctionId)
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    AuctionId = x.AuctionId,
                    Content = x.Content,
                    UserId = x.UserId,
                    PostedOn = x.PostedOn,
                    UserUserName = x.User.Email,
                })
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return comments;
        }

        public int GetCommentsCount(int auctionId)
        {
            return this.commentsRepository.AllAsNoTracking()
                .Where(x => x.AuctionId == auctionId)
                .Count();
        }

        public bool OwnedByUser(string userId, int commentId)
        {
            return this.commentsRepository.All().Any(c => c.Id == commentId && c.UserId == userId);
        }
    }
}
