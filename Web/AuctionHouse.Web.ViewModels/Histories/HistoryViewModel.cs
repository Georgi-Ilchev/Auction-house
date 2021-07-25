namespace AuctionHouse.Web.ViewModels.Histories
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class HistoryViewModel : IMapFrom<History>
    {
        public string UserId { get; set; }

        public int AuctionId { get; set; }

        public decimal BidAmount { get; set; }
    }
}
