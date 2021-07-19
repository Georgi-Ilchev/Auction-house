namespace AuctionHouse.Web.ViewModels.Users
{
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public decimal Balance { get; set; }

        public decimal VirtualBalance { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
