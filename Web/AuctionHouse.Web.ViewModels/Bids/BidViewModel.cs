namespace AuctionHouse.Web.ViewModels.Bids
{
    using System;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class BidViewModel : IMapFrom<Bid>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal BidAmount { get; set; }

        public int AuctionId { get; set; }

        public Auction Auction { get; set; }
    }
}
