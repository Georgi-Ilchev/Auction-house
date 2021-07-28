namespace AuctionHouse.Web.Hubs
{
    using System.Threading.Tasks;
    using AuctionHouse.Web.ViewModels.Bids;
    using Microsoft.AspNetCore.SignalR;

    public class BidsHub : Hub
    {
        public async Task SendUpdates(CurrentBidViewModel model)
        {
            await this.Clients.All.SendAsync("RefreshBids", model);
        }

        public async Task SendUpdates2()
        {
            await this.Clients.All.SendAsync("RefreshBids");
        }
    }
}
