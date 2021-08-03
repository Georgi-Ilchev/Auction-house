namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System.Collections.Generic;

    public class ListAuctionsViewModel : PagingViewModel
    {
        public string Category { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<ListAuctionViewModel> Auctions { get; set; }
    }
}
