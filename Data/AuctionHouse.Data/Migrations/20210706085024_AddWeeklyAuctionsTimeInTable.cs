using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class AddWeeklyAuctionsTimeInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndPromoted",
                table: "Auctions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartPromoted",
                table: "Auctions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPromoted",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "StartPromoted",
                table: "Auctions");
        }
    }
}
