namespace AuctionHouse.Data.Models
{
    using AuctionHouse.Data.Common.Models;

    public class Bid : BaseModel<int>
    {
        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal Bidding { get; set; }
    }
}
