using AuctionHouse.Data.Common.Repositories;
using AuctionHouse.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionHouse.Web.Areas.Administration.Controllers
{
    public class UserController : Controller
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserController(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        //public IActionResult GetAll(int page, int itemsPerPage = 8, int id = 1)
        //{
        //    const int ItemsPerPage = 8;

        //    if (id <= 0)
        //    {
        //        return this.NotFound();
        //    }

        //    var accounts = this.userRepository.AllAsNoTracking()
        //        .OrderByDescending(x => x.Id)
        //        .Skip((page - 1) * itemsPerPage)
        //        .Take(itemsPerPage)
        //        .ToList();

        //    var viewModel = new ListUsersViewModel
        //    {
        //        ItemsPerPage = ItemsPerPage,
        //        PageNumber = id,
        //        Users = accounts,

        //    };

        //    return this.View(viewModel);
        //}

        //public IActionResult GiveMoney()
        //{

        //}
    }
}
