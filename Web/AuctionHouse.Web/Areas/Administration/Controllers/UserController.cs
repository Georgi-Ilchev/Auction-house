using AuctionHouse.Data.Common.Repositories;
using AuctionHouse.Data.Models;
using AuctionHouse.Services.Data;
using AuctionHouse.Web.Areas.Administration.Views.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> GetAlll(int id = 1)
        {
            //var users = await this.userService.GetAll<UserViewModel>();

            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            //var accounts = this.userRepository.AllAsNoTracking()
            //    .OrderByDescending(x => x.Id)
            //    .Skip((page - 1) * itemsPerPage)
            //    .Take(itemsPerPage)
            //    .ToList();

            var viewModel = new ListUsersViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                //Users = users,
            };

            return this.View(viewModel);
        }

        //public IActionResult GiveMoney()
        //{

        //}
    }
}
