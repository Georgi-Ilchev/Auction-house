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
                PostedOn = DateTime.UtcNow.ToLocalTime(),
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

        public bool OwnedByUser(string userId, int commentId)
        {
            return this.commentsRepository.All().Any(c => c.Id == commentId && c.UserId == userId);
        }

        public IEnumerable<CommentViewModel> GetAll(int auctionId, int page, int itemsPerPage = 8)
        {
            var comments = this.commentsRepository.All()
                .AsQueryable()
                .Where(x => x.AuctionId == auctionId)
                .Select(x => new CommentViewModel
                {
                    AuctionId = x.AuctionId,
                    Content = x.Content,
                    UserId = x.UserId,
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
    }
}
