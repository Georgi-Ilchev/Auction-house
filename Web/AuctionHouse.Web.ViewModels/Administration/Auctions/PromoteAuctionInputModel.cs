namespace AuctionHouse.Web.ViewModels.Administration.Auctions
{
    using System;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class PromoteAuctionInputModel : IMapFrom<Auction>
    {
        public int Id { get; set; }

        public DateTime PromoteEnd { get; set; }
    }
}
