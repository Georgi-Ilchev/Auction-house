using AuctionHouse.Data.Models;
using AuctionHouse.Services.Mapping;

namespace AuctionHouse.Web.ViewModels.Auctions
{
    public class ImagesViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Extension { get; set; }
    }
}
