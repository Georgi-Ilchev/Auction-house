namespace AuctionHouse.Web.ViewModels.Auctions
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateAuctionInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Auction validity (in days)")]
        public int Timer { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
