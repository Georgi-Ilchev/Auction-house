namespace AuctionHouse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    public class Bid : BaseModel<int>
    {
        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal BidAmount { get; set; }

        public string LastBidder { get; set; }
    }
}
