namespace AuctionHouse.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    public class ListCommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
