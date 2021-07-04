using AuctionHouse.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionHouse.Data.Models
{
    public class Bit : BaseModel<int>
    {
        public int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal Bidding { get; set; }
    }
}
