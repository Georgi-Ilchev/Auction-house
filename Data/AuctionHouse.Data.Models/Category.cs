namespace AuctionHouse.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Categories = new HashSet<Category>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }

        // public string ImageUrl { get; set; }
    }
}
