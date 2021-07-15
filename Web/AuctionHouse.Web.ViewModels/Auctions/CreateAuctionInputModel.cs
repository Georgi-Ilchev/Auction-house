namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class CreateAuctionInputModel
    {
        [Required]
        [StringLength(
            AuctionNameMaxLength,
            ErrorMessage = "Auction name must be between {2} and {1} characters long.",
            MinimumLength = AuctionNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            DescriptionMaxLength,
            ErrorMessage = "Description must be between {2} and {1} characters long.",
            MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Range(ActiveDaysMin, ActiveDaysMax)]
        [Display(Name = "Аuction validity (1-30 days)")]
        public int ActiveDays { get; set; }

        public DateTime ActiveTo { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
