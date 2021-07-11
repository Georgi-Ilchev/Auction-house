using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class AddLastBidderToAuctionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatestBidder",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatestBidder",
                table: "Auctions");
        }
    }
}
