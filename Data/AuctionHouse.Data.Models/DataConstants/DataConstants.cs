namespace AuctionHouse.Data.Models.DataConstants
{
    public class DataConstants
    {
        // Auction
        public const int AuctionNameMinLength = 3;
        public const int AuctionNameMaxLength = 30;

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 150;

        public const double PriceMinValue = 1.0;
        public const double PriceMaxValue = double.MaxValue;

        public const int ActiveDaysMin = 1;
        public const int ActiveDaysMax = 30;

        // Comment
        public const int ContentMaxLength = 300;
        public const int ContentMinLength = 3;
    }
}
