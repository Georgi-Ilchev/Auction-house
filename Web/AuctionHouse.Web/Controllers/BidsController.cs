namespace AuctionHouse.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Bids;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BidsController : BaseController
    {
        private readonly IBidsService bidsService;

        public BidsController(IBidsService bidsService)
        {
            this.bidsService = bidsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CurrentBidViewModel>> Bid(MakeBidInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userEmail = this.User.FindFirst(ClaimTypes.Email).Value;

            await this.bidsService.AddBidAsync(userId, input.AuctionId, input.Bidding);

            var currentBid = this.bidsService.GetSumBids(input.AuctionId);
            var latestBidder = this.bidsService.GetUser(userId, userEmail);

            await this.bidsService.UpdateAsync(input.AuctionId, input.LastBidder = latestBidder);

            var currentBidView = new CurrentBidViewModel
            {
                CurrentBid = currentBid,
                LastBidder = latestBidder.Email,
            };

            return currentBidView;
        }
    }
}
