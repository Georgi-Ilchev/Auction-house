namespace AuctionHouse.Services.Data.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AuctionHouse.Data.Models;

    public static class Comments
    {
        public static IEnumerable<Comment> AddComments()
        {
            return Enumerable.Range(0, 10).Select(i => new Comment() { AuctionId = 1 });
        }
    }
}
