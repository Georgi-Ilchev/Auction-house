namespace AuctionHouse.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class BidHub : Hub
    {
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

        public async Task JoinGroup(string group)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, group);
        }

        public async Task SendToGroup(string group, string currentBid, string lastBidder)
        {
            await this.Clients.Group(group).SendAsync("RefreshBids", currentBid, lastBidder);
        }

        //public override Task OnConnectedAsync()
        //{
        //    Environments.ConnectionId = this.Context.ConnectionId;
        //    return base.OnConnectedAsync();
        //}
    }
}
