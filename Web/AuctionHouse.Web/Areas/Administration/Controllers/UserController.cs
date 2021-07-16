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

        public async Task<IActionResult> Index(int page = 1)
        {
            const int ItemsPerPage = 8;

            if (page <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new ListUsersViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                Users = await this.userService.GetAllAsync(page, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        //public IActionResult GiveMoney()
        //{

        //}
    }
}
