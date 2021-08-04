using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionHouse.Web.ViewModels.Comments
{
    public class ListCommentsViewModel : PagingViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
