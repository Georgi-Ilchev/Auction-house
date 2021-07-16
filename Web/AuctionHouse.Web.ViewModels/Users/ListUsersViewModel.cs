namespace AuctionHouse.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using AuctionHouse.Web.ViewModels;

    public class ListUsersViewModel : PagingViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
