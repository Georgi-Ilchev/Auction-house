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
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<CurrentBidViewModel>> Set(MakeBidInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.bidsService.SetBidAsync(userId, input.AuctionId, input.Bidding);

            var currentBid = this.bidsService.GetSumBids(input.AuctionId);

            return new CurrentBidViewModel { CurrentBid = currentBid };
        }
    }
}
