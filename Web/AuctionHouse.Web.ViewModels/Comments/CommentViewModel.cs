﻿namespace AuctionHouse.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [Required]
        [StringLength(
            ContentMaxLength,
            ErrorMessage = "Comment message must be between {2} and {1} characters long.",
            MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public TimeSpan PostedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int AuctionId { get; set; }

        public Auction Auction { get; set; }
    }
}
