namespace AuctionHouse.Web.ViewModels.Bids
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class LastUserBidViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}
