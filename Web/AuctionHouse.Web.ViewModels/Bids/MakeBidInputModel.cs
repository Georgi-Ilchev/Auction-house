namespace AuctionHouse.Web.ViewModels.Bids
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MakeBidInputModel
    {
        public int AuctionId { get; set; }

        [Range(1, 1_000_000)]
        public decimal Bidding { get; set; }

        // public DateTime Timestamp { get; set; }
    }
}
