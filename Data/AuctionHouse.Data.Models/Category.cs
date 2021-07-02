namespace AuctionHouse.Data.Models
{
    using System.Collections.Generic;

    using AuctionHouse.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Categories = new HashSet<Category>();
        }

        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
