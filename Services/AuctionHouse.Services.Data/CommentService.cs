namespace AuctionHouse.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;

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
                PostedOn = DateTime.UtcNow,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
