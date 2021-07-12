namespace AuctionHouse.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    public class PostCommentInputModel
    {
        // for bin
        public int AuctionId { get; set; }

        public ICollection<CommentViewModel> Bids { get; set; }
    }
}
