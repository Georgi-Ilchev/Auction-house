namespace AuctionHouse.Web.ViewModels.Images
{
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Extension { get; set; }
    }
}
