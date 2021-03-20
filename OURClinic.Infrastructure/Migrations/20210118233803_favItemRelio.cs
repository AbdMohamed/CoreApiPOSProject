using Microsoft.EntityFrameworkCore.Migrations;

namespace OURCart.Infrastructure.Migrations
{
    public partial class favItemRelio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Items",
                table: "CartProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Items_FkItemId",
                table: "CartProducts",
                column: "FkItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Items_FkItemId",
                table: "CartProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Items",
                table: "CartProducts",
                column: "FkItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
