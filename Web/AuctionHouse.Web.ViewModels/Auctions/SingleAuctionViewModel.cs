﻿namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AutoMapper;

    public class SingleAuctionViewModel : IMapFrom<Auction>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string UserUserName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Auction, SingleAuctionViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                  opt.MapFrom(x =>
                  "/images/auctions/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}