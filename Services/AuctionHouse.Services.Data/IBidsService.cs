﻿namespace AuctionHouse.Services.Data
{
    using System.Threading.Tasks;

    using AuctionHouse.Web.ViewModels.Bids;

    public interface IBidsService
    {
        Task AddBidAsync(string userId, int auctionId, decimal price);

        decimal GetSumBids(int auctionId);

        LastUserBidViewModel GetUser(string userId, string email);

        Task UpdateAsync(int id, LastUserBidViewModel input);
    }
}
