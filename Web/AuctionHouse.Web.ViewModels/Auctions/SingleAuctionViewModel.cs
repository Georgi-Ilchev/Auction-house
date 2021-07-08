namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AuctionHouse.Web.ViewModels.Bids;
    using AuctionHouse.Web.ViewModels.Images;
    using AutoMapper;

    public class SingleAuctionViewModel : IMapFrom<Auction>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal BidsAmount { get; set; }

        public string CategoryName { get; set; }

        public string UserUserName { get; set; }

        public string UserId { get; set; }

        public DateTime Timestamp { get; set; }

        // changed here
        public ApplicationUser LatestBidder { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Auction, SingleAuctionViewModel>()
                .ForMember(x => x.BidsAmount, opt =>
                    opt.MapFrom(x => x.Bids.Sum(a => a.BidAmount)))
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
            "/images/auctions/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
