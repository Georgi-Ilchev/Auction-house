namespace AuctionHouse.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.Controllers;
    using AuctionHouse.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : BaseController
    {
        private readonly IUserService userService;

        public GiftController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        [Authorize]
        public async Task<ActionResult<CurrentBalanceViewModel>> GiveMoney(GiveMoneyInputModel input)
        {
            await this.userService.AddMoneyAsync(input.UserId, input.Amount);

            var userBalance = this.userService.GetUserBalance(input.UserId);

            var currentBalance = new CurrentBalanceViewModel
            {
                UserId = input.UserId,
                Balance = userBalance,
            };

            return currentBalance;
        }
    }
}
