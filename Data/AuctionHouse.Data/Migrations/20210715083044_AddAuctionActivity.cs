using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class AddAuctionActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timer",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Auctions",
                newName: "ActiveTo");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "ActiveTo",
                table: "Auctions",
                newName: "Timestamp");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Timer",
                table: "Auctions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
