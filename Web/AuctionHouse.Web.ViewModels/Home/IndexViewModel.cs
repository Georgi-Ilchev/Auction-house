namespace AuctionHouse.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int AuctionsCount { get; set; }

        public int CategoriesCount { get; set; }

        public decimal Balance { get; set; }

        public decimal VirtualBalance { get; set; }

        public IEnumerable<IndexPageAuctionViewModel> WeeklyAuctions { get; set; }
    }
}
