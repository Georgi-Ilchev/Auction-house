namespace AuctionHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class Auction : BaseDeletableModel<int>
    {
        public Auction()
        {
            this.Images = new HashSet<Image>();
            this.Bids = new HashSet<Bid>();
        }

        [Required]
        [MaxLength(AuctionNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        public bool IsAuctionOfTheWeek { get; set; }

        public DateTime? StartPromoted { get; set; }

        public DateTime? EndPromoted { get; set; }

        public TimeSpan Timer { get; set; }

        public DateTime Timestamp { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string LastBidder { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
