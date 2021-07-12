namespace AuctionHouse.Services.Data
{
    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }
    }
}
