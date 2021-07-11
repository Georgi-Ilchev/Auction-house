namespace AuctionHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Extension { get; set; }

        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }
    }
}
