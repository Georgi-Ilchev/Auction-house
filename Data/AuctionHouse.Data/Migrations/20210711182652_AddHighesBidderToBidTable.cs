using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class AddHighesBidderToBidTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastBidder",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastBidder",
                table: "Bids");
        }
    }
}
