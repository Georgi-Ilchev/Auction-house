namespace AuctionHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AuctionHouse.Data.Common.Repositories;
    using AuctionHouse.Data.Models;
    using AuctionHouse.Services.Mapping;
    using AuctionHouse.Web.ViewModels.Auctions;
    using AuctionHouse.Web.ViewModels.Images;

    public class AuctionService : IAuctionService
    {
        private readonly string[] allowedExtensionsForImage = new[] { "jpg", "png", "JPG", "PNG" };
        private readonly IDeletableEntityRepository<Auction> auctionsRepository;

        public AuctionService(IDeletableEntityRepository<Auction> auctionsRepository)
        {
            this.auctionsRepository = auctionsRepository;
        }

        public async Task CreateAsync(CreateAuctionInputModel input, string userId, string imagePath)
        {
            var auction = new Auction()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                Timer = TimeSpan.FromDays(input.Timer),
                CategoryId = input.CategoryId,
                UserId = userId,
            };

            Directory.CreateDirectory($"{imagePath}/auctions/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensionsForImage.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
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

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 8)
        {
            var auctions = this.auctionsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();

            return auctions;
        }

        public int GetAuctionsCount()
        {
            return this.auctionsRepository.All().Count();
        }

        public T GetById<T>(int id)
        {
            var auction = this.auctionsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return auction;
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

        public async Task Delete(int auctionId)
        {
            var auction = this.auctionsRepository.All().FirstOrDefault(a => a.Id == auctionId);

            this.auctionsRepository.Delete(auction);
            await this.auctionsRepository.SaveChangesAsync();
        }

        public bool OwnedByUser(string userId, int auctionId)
        {
            return this.auctionsRepository.All().Any(c => c.Id == auctionId && c.UserId == userId);
        }
    }
}
