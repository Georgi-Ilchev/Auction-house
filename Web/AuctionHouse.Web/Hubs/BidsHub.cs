namespace AuctionHouse.Web.Hubs
{
    using System;
    using System.Threading.Tasks;
    using AuctionHouse.Web.ViewModels.Bids;
    using Microsoft.AspNetCore.SignalR;

    public class BidsHub : Hub
    {
        //public async Task SendUpdates(CurrentBidViewModel model)
        //{
        //    await this.Clients.All.SendAsync("RefreshBids", model);
        //}

        //public async Task SendUpdates2()
        //{
        //    await this.Clients.All.SendAsync("RefreshBids");
        //}

        public async Task Send(string currentBid, string lastBidder)
        {
            try
            {
                if (!string.IsNullOrEmpty(currentBid))
                {
                    await this.Clients.All.SendAsync("RefreshBids", currentBid, lastBidder);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
