namespace AuctionHouse.Web.ViewModels.Auctions
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class EditAuctionInputModel : BaseAuctionInputModel, IMapFrom<Auction>
    {
        public int Id { get; set; }
    }
}
