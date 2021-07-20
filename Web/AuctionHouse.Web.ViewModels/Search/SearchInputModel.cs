namespace AuctionHouse.Web.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchInputModel : PagingViewModel
    {
        public IEnumerable<int> Categories { get; set; }
    }
}
