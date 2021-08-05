using AuctionHouse.Data.Models;
using AuctionHouse.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionHouse.Web.ViewModels.Comments
{
    public class ListCommentsViewModel : PagingViewModel, IMapFrom<Auction>
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
