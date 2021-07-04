namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System.Collections.Generic;

    public class ListAuctionsViewModel
    {
        public IEnumerable<ListAuctionViewModel> Auctions { get; set; }

        public int PageNumber { get; set; }
    }
}
