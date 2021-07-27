using AuctionHouse.Services.Data;
using AuctionHouse.Web.ViewModels.Bids;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuctionHouse.Web.Hubs
{
    public class AuctionHub : Hub
    {
        private readonly IBidsService bidsService;

        public AuctionHub(IBidsService bidsService)
        {
            this.bidsService = bidsService;
        }
    }
}
