using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class UpdateAuctionAndBidTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LatestBidder",
                table: "Auctions",
                newName: "LastBidder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastBidder",
                table: "Auctions",
                newName: "LatestBidder");
        }
    }
}
