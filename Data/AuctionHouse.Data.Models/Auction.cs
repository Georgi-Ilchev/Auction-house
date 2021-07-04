namespace AuctionHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    public class Auction : BaseDeletableModel<int>
    {
        public Auction()
        {
            this.Images = new HashSet<Image>();
            this.Bids = new HashSet<Bid>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool IsAuctionOfTheWeek { get; set; }

        public TimeSpan Timer { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
