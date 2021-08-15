namespace AuctionHouse.Services.Data.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AuctionHouse.Data.Models;

    public static class Auctions
    {
        public static IEnumerable<Auction> AddAuctions()
        {
            return Enumerable.Range(0, 10).Select(i => new Auction());
        }

        public static IEnumerable<Auction> AddWeeklyAuctions()
        {
            return Enumerable.Range(0, 10).Select(i => new Auction()
            {
                IsAuctionOfTheWeek = true,
                IsActive = true,
                StartPromoted = DateTime.UtcNow,
                EndPromoted = DateTime.UtcNow.ToLocalTime().AddDays(1),
            });
        }
    }
}
