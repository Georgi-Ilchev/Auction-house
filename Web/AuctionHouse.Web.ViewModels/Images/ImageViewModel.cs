namespace AuctionHouse.Web.ViewModels.Images
{
    using System.ComponentModel.DataAnnotations;

    public class ImageViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Extension { get; set; }
    }
}
