namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System.Collections.Generic;

    public class ListAuctionsViewModel : PagingViewModel
    {
        public IEnumerable<ListAuctionViewModel> Auctions { get; set; }
    }
}
