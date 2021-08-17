namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AuctionHouse.Web.ViewModels.Auctions;

    using static AuctionHouse.Data.Models.DataConstants.DataConstants;

    public class AuctionService : IAuctionService
    {
        private readonly string[] allowedExtensionsForImage = new[] { "jpg", "png", "JPG", "PNG" };
        private readonly IDeletableEntityRepository<Auction> auctionsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public AuctionService(
            IDeletableEntityRepository<Auction> auctionsRepository,
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.auctionsRepository = auctionsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<ListAuctionViewModel>> GetAll<TListAuctionViewModel>(int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.IsPaid == false)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<ListAuctionViewModel>()
                .ToList();

            foreach (var auction in auctions)
            {
                if (auction.IsActive == true && DateTime.UtcNow.ToLocalTime() > auction.ActiveTo)
                {
                    auction.IsActive = false;
                }

                if (auction.IsActive == false && auction.LastBidder != null)
                {
                    auction.IsSold = true;
                }
            }

            await this.auctionsRepository.SaveChangesAsync();

            return auctions;
        }

        public async Task<IEnumerable<ListAuctionViewModel>> GetAllForSearch<TListAuctionViewModel>(int category, int page, int itemsPerPage = 8)
        {
            var auctionsQuery = this.auctionsRepository.AllAsNoTracking().AsQueryable();

            if (this.categoriesRepository.All().Any(c => c.Id == category))
            {
                auctionsQuery = auctionsQuery.Where(c => c.Category.Id == category);
            }

            var auctions = auctionsQuery
                .Where(x => x.IsPaid == false)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<ListAuctionViewModel>()
                .ToList();

            foreach (var auction in auctions)
            {
                if (auction.IsActive == true && DateTime.UtcNow.ToLocalTime() > auction.ActiveTo)
                {
                    auction.IsActive = false;
                }

                if (auction.IsActive == false && auction.LastBidder != null)
                {
                    auction.IsSold = true;
                }
            }

            await this.auctionsRepository.SaveChangesAsync();

            return auctions;
        }

        public IEnumerable<T> GetUserAuctions<T>(string userId, int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId && x.IsPaid == false)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return auctions;
        }

        public IEnumerable<T> GetAllUserPurchases<T>(string userEmail, int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.LastBidder == userEmail /*&& x.IsSold == true*/ && x.IsPaid == true)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return auctions;
        }

        public IEnumerable<T> GetAllUserSales<T>(string userId, int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId && x.IsSold == true && x.IsPaid == true)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return auctions;
        }

        public IEnumerable<T> GetSearch<T>(string search, int page, int itemsPerPage = 8)
        {
            var auctionsQuery = this.auctionsRepository.AllAsNoTracking().Where(x => x.IsPaid == false).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                auctionsQuery = auctionsQuery.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            }

            var auctions = auctionsQuery
                .OrderByDescending(x => x.Id)
                //.Skip((page - 1) * itemsPerPage)
                //.Take(itemsPerPage)
                .To<T>()
                .ToList();

            return auctions;
        }

        public int GetAuctionsCount()
        {
            return this.auctionsRepository.All()
                .Where(x => x.IsPaid == false)
                .Count();
        }

        public int GetAuctionsCountByCategory(int category)
        {
            return this.auctionsRepository.All()
                .Where(x => x.CategoryId == category && x.IsPaid == false)
                .Count();
        }

        public int GetUserAuctionsCount(string userId)
        {
            return this.auctionsRepository.All()
                .Where(x => x.UserId == userId &&
                            x.IsPaid == false)
                .Count();
        }

        public int GetUserPurchasesCount(string userEmail)
        {
            return this.auctionsRepository.All()
                 .Where(x => x.LastBidder == userEmail &&
                             x.IsPaid == true)
                 .Count();
        }

        public int GetUserSalesCount(string userId)
        {
            return this.auctionsRepository.All()
                .Where(x => x.UserId == userId && x.IsPaid == true)
                .Count();
        }

        public T GetById<T>(int id)
        {
            var auction = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return auction;
        }

        public T GetByIdWithPaging<T>(int id, int page, int itemsPerPage = 8)
        {
            var auction = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .FirstOrDefault();

            return auction;
        }

        public async Task CreateAsync(CreateAuctionInputModel input, string userId, string imagePath)
        {
            if (input.ActiveDays < ActiveDaysMin || input.ActiveDays > ActiveDaysMax)
            {
                throw new Exception($"The auction activity cannot be less than {ActiveDaysMin} and more than {ActiveDaysMax} days.");
            }

            var auction = new Auction()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                CurrentPrice = input.Price,
                CreatedOn = DateTime.UtcNow.ToLocalTime(),
                ActiveTo = DateTime.UtcNow.ToLocalTime().AddDays(input.ActiveDays),
                CategoryId = input.CategoryId,
                UserId = userId,
                IsActive = true,
                IsSold = false,
                IsPaid = false,
            };

            if (!this.categoriesRepository.All().Any(c => c.Id == input.CategoryId))
            {
                throw new Exception($"Invalid category.");
            }

            Directory.CreateDirectory($"{imagePath}/auctions/");

            if (input.Images.Count() <= ImagesMaxCount && input.Images.Count() >= ImagesMinCount)
            {
                foreach (var image in input.Images)
                {
                    var extension = Path.GetExtension(image.FileName).TrimStart('.');

                    if (!this.allowedExtensionsForImage.Any(x => extension.EndsWith(x)))
                    {
                        throw new Exception($"Invalid image extension {extension}.");
                    }

                    var dataImage = new Image
                    {
                        UserId = userId,
                        Extension = extension,
                    };
                    auction.Images.Add(dataImage);

                    var path = $"{imagePath}/auctions/{dataImage.Id}.{extension}";

                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                }
            }
            else
            {
                throw new Exception($"Maximum {ImagesMaxCount} images.");
            }

            await this.auctionsRepository.AddAsync(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task PromoteAuctionOfWeek(DateTime promoteEnd, int auctionId)
        {
            var auction = this.auctionsRepository
                .All()
                .FirstOrDefault(a => a.Id == auctionId);

            auction.IsAuctionOfTheWeek = true;
            auction.StartPromoted = DateTime.UtcNow.ToLocalTime();
            auction.EndPromoted = promoteEnd;

            this.auctionsRepository.Update(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task UnPromoteAuctionOfWeek(int auctionId)
        {
            var auction = this.auctionsRepository
                .All()
                .FirstOrDefault(a => a.Id == auctionId);

            auction.IsAuctionOfTheWeek = false;
            auction.StartPromoted = null;
            auction.EndPromoted = null;

            this.auctionsRepository.Update(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EditAuctionInputModel input)
        {
            if (!this.categoriesRepository.All().Any(c => c.Id == input.CategoryId))
            {
                throw new Exception($"Invalid category.");
            }

            var auctions = this.auctionsRepository.All().FirstOrDefault(x => x.Id == id);
            auctions.Name = input.Name;
            auctions.Description = input.Description;
            auctions.CategoryId = input.CategoryId;

            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task Delete(int auctionId)
        {
            var auction = this.auctionsRepository.All().FirstOrDefault(a => a.Id == auctionId);

            this.auctionsRepository.Delete(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task UpdateDbAuction(int auctionId)
        {
            var dbAuction = this.auctionsRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Id == auctionId);

            if (dbAuction.IsActive == true && DateTime.UtcNow.ToLocalTime() > dbAuction.ActiveTo)
            {
                dbAuction.IsActive = false;
            }

            if (dbAuction.IsActive == false && dbAuction.LastBidder != null)
            {
                dbAuction.IsSold = true;
            }

            if (dbAuction.EndPromoted < DateTime.UtcNow.ToLocalTime())
            {
                dbAuction.StartPromoted = null;
                dbAuction.EndPromoted = null;
                dbAuction.IsAuctionOfTheWeek = false;
            }

            this.auctionsRepository.Update(dbAuction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public bool OwnedByUser(string userId, int auctionId)
        {
            return this.auctionsRepository.All().Any(c => c.Id == auctionId && c.UserId == userId);
        }

        public bool IsAuctionExisting(int auctionId)
        {
            return this.auctionsRepository
                .All()
                .Any(x => x.Id == auctionId);
        }

        public bool IsThereLastBidder(int auctionId)
        {
            return this.auctionsRepository.All()
                .Any(x => x.Id == auctionId && x.LastBidder != null);
        }

        public List<T> GetWeeklyAuctions<T>()
        {
            return this.auctionsRepository.All()
                .Where(x => x.IsAuctionOfTheWeek == true)
                .To<T>()
                .ToList();
        }
    }
}
