namespace AuctionHouse.Web.ViewModels.Bids
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class MakeBidInputModel
    {
        public int AuctionId { get; set; }

        [Range(BidMinValue, BidMaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Bidding { get; set; }

        public ICollection<BidViewModel> Bids { get; set; }

        public LastUserBidViewModel LastBidder { get; set; }
    }
}
