namespace AuctionHouse.Services.Data.Tests.Models
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class WeeklyAuctionModel : IMapFrom<Auction>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsAuctionOfTheWeek { get; set; }
    }
}
