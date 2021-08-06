namespace AuctionHouse.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Range(BalanceMinValue, BalanceMaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Balance { get; set; }

        public decimal VirtualBalance { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
