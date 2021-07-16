using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionHouse.Web.ViewModels.Users
{
    public class CurrentBalanceViewModel
    {
        public string UserId { get; set; }

        public decimal Balance { get; set; }
    }
}
