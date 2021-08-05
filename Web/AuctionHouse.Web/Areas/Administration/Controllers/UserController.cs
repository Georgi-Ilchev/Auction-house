namespace AuctionHouse.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new ListUsersViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Users = await this.userService.GetAllAsync(id, ItemsPerPage),
                Count = this.userService.UsersCount(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult SingleUser(string userId)
        {
            if (userId == string.Empty)
            {
                return this.NotFound();
            }

            var user = this.userService.GetUser(userId);

            return this.View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SingleUser(string userId, decimal balance)
        {
            if (userId == string.Empty)
            {
                return this.NotFound();
            }

            await this.userService.AddMoneyAsync(userId, balance);

            return this.RedirectToAction("Index");
        }
    }
}
