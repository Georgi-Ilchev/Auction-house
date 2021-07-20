namespace AuctionHouse.Data.Models
{
    using AuctionHouse.Data.Common.Models;

    public class History : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal BidAmount { get; set; }
    }
}
