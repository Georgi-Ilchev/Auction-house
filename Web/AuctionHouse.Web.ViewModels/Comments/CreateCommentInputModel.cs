namespace AuctionHouse.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class CreateCommentInputModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
             ContentMaxLength,
             ErrorMessage = "Comment message must be between {2} and {1} characters long.",
             MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}
