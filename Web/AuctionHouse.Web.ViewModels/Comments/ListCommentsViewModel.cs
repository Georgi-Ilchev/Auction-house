namespace AuctionHouse.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class ListCommentsViewModel : PagingViewModel, IMapFrom<Auction>
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
