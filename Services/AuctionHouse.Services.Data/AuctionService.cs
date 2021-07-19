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

    public class AuctionService : IAuctionService
    {
        private readonly string[] allowedExtensionsForImage = new[] { "jpg", "png", "JPG", "PNG" };
        private readonly IDeletableEntityRepository<Auction> auctionsRepository;
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        private const int ActiveDaysMin = 1;
        private const int ActiveDaysMax = 30;

        public AuctionService(
            IDeletableEntityRepository<Auction> auctionsRepository,
            IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.auctionsRepository = auctionsRepository;
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.IsPaid == false)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

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

        public IEnumerable<T> GetSearch<T>(string search)
        {
            if (search == null)
            {
                search = string.Empty;
            }

            var auctions = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.Name.ToLower().Contains(search.ToLower()))
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();

            return auctions;
        }

        //public IEnumerable<T> GetAllByCategory<T>(int page, int category, int itemsPerPage = 8)
        //{
        //    var auctions = this.auctionsRepository.AllAsNoTracking()
        //        .OrderByDescending(x => x.Id)
        //        .Where(x => x.CategoryId == category)
        //        .Skip((page - 1) * itemsPerPage)
        //        .Take(itemsPerPage)
        //        .To<T>()
        //        .ToList();

        //    return auctions;
        //}

        public int GetAuctionsCount()
        {
            return this.auctionsRepository.All()
                .Where(x => x.IsPaid == false)
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

            await this.auctionsRepository.AddAsync(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public async Task PromoteAuctionOfWeek(DateTime promoteEnd, int auctionId)
        {
            var auction = this.auctionsRepository
                .All()
                .FirstOrDefault(a => a.Id == auctionId);

            auction.IsAuctionOfTheWeek = true;
            auction.StartPromoted = DateTime.UtcNow;
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

            if (DateTime.UtcNow.ToLocalTime() > dbAuction.ActiveTo)
            {
                dbAuction.IsActive = false;
            }

            if (dbAuction.IsActive == false && dbAuction.LastBidder != null)
            {
                dbAuction.IsSold = true;
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

        public IEnumerable<T> GetWeeklyAuctions<T>()
        {
            return this.auctionsRepository.All()
                .Where(x => x.IsAuctionOfTheWeek == true)
                .To<T>()
                .ToList();
        }
    }
}
