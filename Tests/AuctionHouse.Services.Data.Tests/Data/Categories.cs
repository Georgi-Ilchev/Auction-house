namespace AuctionHouse.Services.Data.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AuctionHouse.Data.Models;

    public static class Categories
    {
        public static IEnumerable<Category> AddCategories()
        {
            return Enumerable.Range(0, 10).Select(i => new Category());
        }
    }
}
