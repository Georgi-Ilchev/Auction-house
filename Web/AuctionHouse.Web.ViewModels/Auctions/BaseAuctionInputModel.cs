namespace AuctionHouse.Web.ViewModels.Auctions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public abstract class BaseAuctionInputModel
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

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
