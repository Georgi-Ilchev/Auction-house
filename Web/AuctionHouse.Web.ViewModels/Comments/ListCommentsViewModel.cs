using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionHouse.Web.ViewModels.Comments
{
    public class ListCommentsViewModel : CommentViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
