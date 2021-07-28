namespace AuctionHouse.Web.ViewModels.Bids
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class CurrentBidViewModel
    {
        public decimal CurrentBid { get; set; }

        public string LastBidder { get; set; }

        [Range(BalanceMinValue, double.PositiveInfinity)]
        public decimal VirtualBalance { get; set; }

        public decimal UserbidsAmount { get; set; }
    }
}
