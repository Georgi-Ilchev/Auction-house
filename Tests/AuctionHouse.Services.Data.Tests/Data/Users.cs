namespace AuctionHouse.Services.Data.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AuctionHouse.Data.Models;

    public static class Users
    {
        public static IEnumerable<ApplicationUser> AddUser()
        {
            return Enumerable.Range(0, 10).Select(i => new ApplicationUser());
        }
    }
}
