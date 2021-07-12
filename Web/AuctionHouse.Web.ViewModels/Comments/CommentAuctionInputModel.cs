﻿namespace AuctionHouse.Web.ViewModels.Comments
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class CommentAuctionInputModel : CommentViewModel, IMapFrom<Auction>
    {
        public int Id { get; set; }
    }
}
