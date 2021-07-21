namespace AuctionHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Common.Models;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public ApplicationUser User { get; set; }

        public int AuctionId { get; set; }

        public Auction Auction { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
