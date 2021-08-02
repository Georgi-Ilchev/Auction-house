namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System.Collections.Generic;

    public class AuctionsViewByCategory : PagingViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<AuctionViewByCategory> Auctions { get; set; }
    }
}
