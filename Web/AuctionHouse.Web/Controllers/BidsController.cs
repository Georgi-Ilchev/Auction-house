namespace AuctionHouse.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.Hubs;
    using AuctionHouse.Web.ViewModels.Bids;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [ApiController]
    [Route("api/[controller]")]
    public class BidsController : BaseController
    {
        private readonly IBidsService bidsService;
        private readonly IHubContext<BidsHub> hubContext;

        public BidsController(IBidsService bidsService, IHubContext<BidsHub> hubContext)
        {
            this.bidsService = bidsService;
            this.hubContext = hubContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CurrentBidViewModel>> Bid(MakeBidInputModel input)
        {
            if (this.bidsService.CheckForCorrectBid(input.Bidding))
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userEmail = this.User.FindFirst(ClaimTypes.Email).Value;

                await this.bidsService.AddBidAsync(userId, input.AuctionId, input.Bidding);
                await this.bidsService.AddBidToHistory(userId, input.AuctionId, input.Bidding);
                await this.bidsService.ReturnBids(userId, input.AuctionId);

                var currentBid = this.bidsService.GetSumBids(input.AuctionId);
                var latestBidder = this.bidsService.GetUser(userId, userEmail);
                var userBidsAmount = this.bidsService.GetUserBids(userId, input.AuctionId);

                await this.bidsService.UpdateAsync(input.AuctionId, input.LastBidder = latestBidder);
                await this.bidsService.GetMoneyFromDbUser(userId, input.Bidding);

                var virtualBalance = this.bidsService.GetDbUserBalance(userId);

                var currentBidView = new CurrentBidViewModel
                {
                    CurrentBid = currentBid,
                    LastBidder = latestBidder.Email,
                    VirtualBalance = virtualBalance,
                    UserbidsAmount = userBidsAmount,
                };

                await this.hubContext.Clients.All.SendAsync("RefreshBids", currentBidView);

                return currentBidView;
            }

            return this.RedirectToAction("/Home/Error");
        }
    }
}
