namespace AuctionHouse.Web.ViewModels.Bids
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MakeBidInputModel
    {
        public int AuctionId { get; set; }

        [Range(10, 5000)]
        public decimal Bidding { get; set; }

        public ICollection<BidViewModel> Bids { get; set; }

        public LastUserBidViewModel LastBidder { get; set; }
    }
}
