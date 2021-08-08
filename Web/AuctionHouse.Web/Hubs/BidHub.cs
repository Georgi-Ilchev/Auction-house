namespace AuctionHouse.Web.Hubs
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    public class BidHub : Hub
    {
        public async Task JoinGroup(string group)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, group);
        }

        public async Task SendToGroup(string group, string currentBid, string lastBidder)
        {
            await this.Clients.Group(group).SendAsync("RefreshBids", currentBid, lastBidder);
        }
    }
}
