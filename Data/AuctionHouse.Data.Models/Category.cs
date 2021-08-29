namespace AuctionHouse.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Auctions = new HashSet<Auction>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<Auction> Auctions { get; set; }
    }
}
