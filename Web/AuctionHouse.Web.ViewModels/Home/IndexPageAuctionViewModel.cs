namespace AuctionHouse.Web.ViewModels.Home
{
    using System.Linq;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AutoMapper;

    public class IndexPageAuctionViewModel : IMapFrom<Auction>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public decimal CurrentPrice { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Auction, IndexPageAuctionViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x =>
                  "/images/auctions/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
