﻿namespace AuctionHouse.Web.Areas.Administration.Views.Users
{
    using System;

    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public decimal Balance { get; set; }
    }
}