using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionHouse.Data.Migrations
{
    public partial class AddAuctionHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Bids_BidId",
                table: "Histories");

            migrationBuilder.RenameColumn(
                name: "BidId",
                table: "Histories",
                newName: "AuctionId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_BidId",
                table: "Histories",
                newName: "IX_Histories_AuctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Auctions_AuctionId",
                table: "Histories",
                column: "AuctionId",
                principalTable: "Auctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Auctions_AuctionId",
                table: "Histories");

            migrationBuilder.RenameColumn(
                name: "AuctionId",
                table: "Histories",
                newName: "BidId");

            migrationBuilder.RenameIndex(
                name: "IX_Histories_AuctionId",
                table: "Histories",
                newName: "IX_Histories_BidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Bids_BidId",
                table: "Histories",
                column: "BidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
