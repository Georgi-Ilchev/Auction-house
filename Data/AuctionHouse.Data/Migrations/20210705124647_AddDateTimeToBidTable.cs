using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class AddDateTimeToBidTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "Bidding",
                table: "Bids",
                newName: "BidAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "BidAmount",
                table: "Bids",
                newName: "Bidding");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Auctions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
