namespace AuctionHouse.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class CommentAuctionInputModel : CommentViewModel, IMapFrom<Auction>
    {
        // test / not in use
        public IEnumerable<CommitCommentViewModel> Comments { get; set; }
    }
}
