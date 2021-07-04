namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System.Linq;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AutoMapper;

    public class ListAuctionViewModel : IMapFrom<Auction>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Auction, ListAuctionViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x =>
                  "/images/auctions/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
