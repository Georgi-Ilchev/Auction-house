namespace AuctionHouse.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Data;
    using AuctionHouse.Web.ViewModels.Administration.Auctions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class AuctionsController : Controller
    {
        private readonly IDeletableEntityRepository<Auction> auctionRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IAuctionService auctionService;

        public AuctionsController(
            IDeletableEntityRepository<Auction> auctionRepository,
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IAuctionService auctionService)
        {
            this.auctionRepository = auctionRepository;
            this.categoriesRepository = categoriesRepository;
            this.userRepository = userRepository;
            this.auctionService = auctionService;
        }

        // GET: Administration/Auctions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.auctionRepository.All().Include(a => a.Category).Include(a => a.User);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Auctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var auction = await this.auctionRepository.All()
                .Include(a => a.Category)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auction == null)
            {
                return this.NotFound();
            }

            return this.View(auction);
        }

        // GET: Administration/Auctions/Create
        public IActionResult Create()
        {
            this.ViewData["CategoryId"] = new SelectList(this.categoriesRepository.All(), "Id", "Id");
            this.ViewData["UserId"] = new SelectList(this.userRepository.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Auctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,IsAuctionOfTheWeek,StartPromoted,EndPromoted,Timer,Timestamp,UserId,CategoryId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Auction auction)
        {
            if (this.ModelState.IsValid)
            {
                await this.auctionRepository.AddAsync(auction);
                await this.auctionRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoriesRepository.All(), "Id", "Id", auction.CategoryId);
            this.ViewData["UserId"] = new SelectList(this.userRepository.All(), "Id", "Id", auction.UserId);
            return this.View(auction);
        }

        // GET: Administration/Auctions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var auction = this.auctionRepository.All().FirstOrDefault(x => x.Id == id);
            if (auction == null)
            {
                return this.NotFound();
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoriesRepository.All(), "Id", "Id", auction.CategoryId);
            this.ViewData["UserId"] = new SelectList(this.userRepository.All(), "Id", "Id", auction.UserId);
            return this.View(auction);
        }

        // POST: Administration/Auctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Price,IsAuctionOfTheWeek,StartPromoted,EndPromoted,Timer,Timestamp,UserId,CategoryId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Auction auction)
        {
            if (id != auction.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.auctionRepository.Update(auction);
                    await this.auctionRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.AuctionExists(auction.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CategoryId"] = new SelectList(this.categoriesRepository.All(), "Id", "Id", auction.CategoryId);
            this.ViewData["UserId"] = new SelectList(this.userRepository.All(), "Id", "Id", auction.UserId);
            return this.View(auction);
        }

        // GET: Administration/Auctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var auction = await this.auctionRepository.All()
                .Include(a => a.Category)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auction == null)
            {
                return this.NotFound();
            }

            return this.View(auction);
        }

        // POST: Administration/Auctions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auction = this.auctionRepository.All().FirstOrDefault(x => x.Id == id);
            this.auctionRepository.Delete(auction);
            await this.auctionRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool AuctionExists(int id)
        {
            return this.auctionRepository.All().Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult AuctionOfTheWeek()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AuctionOfTheWeek(PromoteAuctionInputModel input, int auctionId)
        {
            await this.auctionService.PromoteAuctionOfWeek(input.PromoteEnd, auctionId);
            return this.Redirect("/Administration/Auctions/Index");
        }

        [HttpPost]
        public async Task<IActionResult> UnPromoteAuctionOfTheWeek(int auctionId)
        {
            await this.auctionService.UnPromoteAuctionOfWeek(auctionId);
            return this.Redirect("/Administration/Auctions/Index");
        }
    }
}
