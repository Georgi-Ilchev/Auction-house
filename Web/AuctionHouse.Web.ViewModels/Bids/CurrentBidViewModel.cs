using AuctionHouse.Data.Models;

namespace AuctionHouse.Web.ViewModels.Bids
{
    public class CurrentBidViewModel
    {
        public decimal CurrentBid { get; set; }

        public ApplicationUser LatestBidder { get; set; }
    }
}
