using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse.Services.Data
{
    public interface IBidsService
    {
        Task SetBidAsync(string userId, int auctionId, decimal price);
    }
}
