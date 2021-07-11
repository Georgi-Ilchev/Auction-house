namespace AuctionHouse.Web.ViewModels.Bids
{
    using AuctionHouse.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MakeBidInputModel
    {
        public int AuctionId { get; set; }

        [Range(1, 1_000_000)]
        public decimal Bidding { get; set; }

        public ICollection<BidViewModel> Bids { get; set; }

        public LastUserBidViewModel LastBidder { get; set; }

        // public DateTime Timestamp { get; set; }

        //public ApplicationUser LatestBidder { get; set; }
    }
}
