﻿namespace AuctionHouse.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class CommentAuctionInputModel : CommentViewModel, IMapFrom<Auction>
    {
        public IEnumerable<CommitCommentViewModel> Comments { get; set; }
    }
}
