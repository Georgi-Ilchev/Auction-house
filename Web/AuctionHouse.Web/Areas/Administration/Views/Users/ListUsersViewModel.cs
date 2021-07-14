namespace AuctionHouse.Web.Areas.Administration.Views.Users
{
    using System.Collections.Generic;

    using AuctionHouse.Web.ViewModels;

    public class ListUsersViewModel : PagingViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
