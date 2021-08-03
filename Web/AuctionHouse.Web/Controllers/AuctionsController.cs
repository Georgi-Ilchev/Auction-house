namespace AuctionHouse.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Auctions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class AuctionsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IAuctionService auctionService;
        private readonly IWebHostEnvironment environment;
        private readonly IUserService userService;
        private readonly IBidsService bidsService;
        private readonly int[] bids = new[] { 10, 20, 50, 100, 200, 300, 500, 1000, 3000, 5000 };

        private readonly IRepository<History> historiesRepository;

        public AuctionsController(
            ICategoriesService categoriesService,
            IAuctionService auctionService,
            IWebHostEnvironment environment,
            IUserService userService,
            IBidsService bidsService,
            IRepository<History> historiesRepository)
        {
            this.categoriesService = categoriesService;
            this.auctionService = auctionService;
            this.environment = environment;
            this.userService = userService;
            this.bidsService = bidsService;
            this.historiesRepository = historiesRepository;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateAuctionInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateAuctionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.auctionService.CreateAsync(input, userId, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            this.TempData["Message"] = "The auction was successfully created.";

            return this.Redirect("/Auctions/All");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.auctionService.OwnedByUser(userId, id))
            {
                return this.Unauthorized();
            }

            var input = this.auctionService.GetById<EditAuctionInputModel>(id);
            input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();

            return this.View(input);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditAuctionInputModel auction)
        {
            if (!this.ModelState.IsValid)
            {
                auction.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();

                return this.View(auction);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.auctionService.OwnedByUser(userId, id))
            {
                return this.Unauthorized();
            }

            await this.auctionService.UpdateAsync(id, auction);

            this.TempData["Message"] = "The auction was successfully updated.";

            return this.RedirectToAction(nameof(this.SingleAuction), new { auctionId = id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int auctionId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.auctionService.OwnedByUser(userId, auctionId))
            {
                return this.Unauthorized();
            }

            if (auctionId == 0)
            {
                return this.NotFound();
            }

            if (!this.auctionService.IsThereLastBidder(auctionId))
            {
                return this.Unauthorized();
            }

            await this.auctionService.Delete(auctionId);

            this.TempData["Message"] = "The auction was successfully deleted.";

            return this.Redirect("/Auctions/All");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MoneyTransfer(int auctionId)
        {
            if (auctionId == 0)
            {
                return this.NotFound();
            }

            var auction = this.auctionService.GetById<SingleAuctionViewModel>(auctionId);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var ownerId = auction.UserId;

            if (!this.auctionService.OwnedByUser(ownerId, auctionId))
            {
                return this.Unauthorized();
            }

            var amount = auction.CurrentPrice;

            var lastUser = this.userService.GetLastBidUser(auction.LastBidder);

            var history = this.historiesRepository.All()
                .FirstOrDefault(x => x.AuctionId == auction.Id && x.UserId == lastUser.Id);

            var virtualBids = history.BidAmount;

            await this.userService.GetFromUser(userId, amount, virtualBids);
            await this.userService.GetToOwner(ownerId, amount, auctionId);

            this.TempData["Message"] = "You have successfully paid";

            return this.Redirect("/Auctions/UserPurchases");
        }

        [Authorize]
        public async Task<IActionResult> All1(int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new ListAuctionsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = await this.auctionService.GetAll<ListAuctionViewModel>(id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetAuctionsCount(),
            };

            //foreach (var auction in viewModel.Auctions)
            //{
            //    await this.auctionService.UpdateDbAuction(auction.Id);
            //}

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult AuctionByUser(int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = new ListAuctionsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = this.auctionService.GetUserAuctions<ListAuctionViewModel>(userId, id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetUserAuctionsCount(userId),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult UserPurchases(int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var userEmail = this.User.FindFirst(ClaimTypes.Email).Value;

            var viewModel = new ListAuctionsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = this.auctionService.GetAllUserPurchases<ListAuctionViewModel>(userEmail, id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetUserPurchasesCount(userEmail),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult UserSales(int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = new ListAuctionsViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = this.auctionService.GetAllUserSales<ListAuctionViewModel>(userId, id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetUserSalesCount(userId),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> SingleAuction(int auctionId)
        {
            if (!this.auctionService.IsAuctionExisting(auctionId))
            {
                return this.NotFound();
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = this.userService.GetUser(userId);
            var auction = this.auctionService.GetById<SingleAuctionViewModel>(auctionId);
            var auctionSum = auction.CurrentPrice;

            var userBidsAmount = this.bidsService.GetUserBids(userId, auction.Id);

            if (DateTime.UtcNow.ToLocalTime() > auction.ActiveTo)
            {
                auction.IsActive = false;
            }

            if (auction.IsActive == false && auction.LastBidder != null)
            {
                auction.IsSold = true;
            }

            if (user.Balance > auctionSum && auction.IsActive == true)
            {
                auction.CanUserBid = true;
            }

            if (auction.EndPromoted < DateTime.UtcNow.ToLocalTime())
            {
                auction.StartPromoted = null;
                auction.EndPromoted = null;
                auction.IsAuctionOfTheWeek = false;
            }

            await this.auctionService.UpdateDbAuction(auctionId);

            this.ViewBag.Balance = user.Balance;
            this.ViewBag.VirtualBalance = user.VirtualBalance;
            this.ViewBag.SupportingBids = this.bids;
            this.ViewBag.UserBidsSum = userBidsAmount;

            return this.View(auction);
        }

        public bool CanUserDeleteAuction(int auctionId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userOwnAuction = this.auctionService.OwnedByUser(userId, auctionId);

            if (!userOwnAuction)
            {
                return false;
            }

            return true;
        }



        // testing
        [Authorize]
        public async Task<IActionResult> All(int category, int id = 1)
        {
            const int ItemsPerPage = 8;

            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new ListAuctionsViewModel
            {
                CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs(),
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Auctions = await this.auctionService.GetAllForSearch<ListAuctionViewModel>(category, id, ItemsPerPage),
                AuctionsCount = this.auctionService.GetAuctionsCount(),
            };

            return this.View(viewModel);
        }
    }
}
