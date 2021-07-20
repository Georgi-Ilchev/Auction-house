namespace AuctionHouse.Web.ViewModels.Bids
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class BidViewModel : IMapFrom<Bid>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal BidAmount { get; set; }

        public int AuctionId { get; set; }

        public Auction Auction { get; set; }

        public string LastBidder { get; set; }
    }
}
