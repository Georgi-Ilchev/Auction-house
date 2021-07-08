namespace AuctionHouse.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Travel" });
            await dbContext.Categories.AddAsync(new Category { Name = "Electronics" });
            await dbContext.Categories.AddAsync(new Category { Name = "Jewelry" });
            await dbContext.Categories.AddAsync(new Category { Name = "Sports" });
            await dbContext.Categories.AddAsync(new Category { Name = "Gifts" });
            await dbContext.Categories.AddAsync(new Category { Name = "Health & Fitness" });
            await dbContext.Categories.AddAsync(new Category { Name = "Services" });
            await dbContext.Categories.AddAsync(new Category { Name = "Event Tickets" });
            await dbContext.Categories.AddAsync(new Category { Name = "Theatre" });
            await dbContext.Categories.AddAsync(new Category { Name = "Art" });
            await dbContext.Categories.AddAsync(new Category { Name = "Unique" });
            await dbContext.Categories.AddAsync(new Category { Name = "Apparel" });

            await dbContext.SaveChangesAsync();
        }
    }
}
