namespace AuctionHouse.Services.Data.Tests.Mocks
{
    using System;

    using AuctionHouse.Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
