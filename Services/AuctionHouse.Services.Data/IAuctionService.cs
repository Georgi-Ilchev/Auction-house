namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Auctions;

    public interface IAuctionService
    {
        Task CreateAsync(CreateAuctionInputModel input);
    }
}
