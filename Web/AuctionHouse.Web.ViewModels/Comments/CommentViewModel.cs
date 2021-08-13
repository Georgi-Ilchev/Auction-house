namespace AuctionHouse.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Write your comment")]
        [StringLength(
             ContentMaxLength,
             ErrorMessage = "Comment message must be between {2} and {1} characters long.",
             MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string PostedOnAsString
            => this.PostedOn.ToString("dd.MM.yyyy HH:mm:ss", CultureInfo.GetCultureInfo("bg-BG"));

        [Required]
        public string UserId { get; set; }

        public int AuctionId { get; set; }

        public string UserUserName { get; set; }
    }
}
