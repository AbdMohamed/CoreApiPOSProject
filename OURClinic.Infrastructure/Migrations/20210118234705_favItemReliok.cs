using Microsoft.EntityFrameworkCore.Migrations;

namespace OURCart.Infrastructure.Migrations
{
    public partial class favItemReliok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favourites_Items",
                table: "favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_favourites_Items_FkItemID",
                table: "favourites",
                column: "FkItemID",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favourites_Items_FkItemID",
                table: "favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_favourites_Items",
                table: "favourites",
                column: "FkItemID",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
