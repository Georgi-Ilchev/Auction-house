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

            await dbContext.SaveChangesAsync();
        }
    }
}
