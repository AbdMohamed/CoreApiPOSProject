using Microsoft.EntityFrameworkCore.Migrations;

namespace OURCart.Infrastructure.Migrations
{
    public partial class updateTranHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Items_FkItemId",
                table: "CartProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_FkItemId",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "ItemBarCodeID",
                table: "userCartItem");

            migrationBuilder.DropColumn(
                name: "fk_itemPackageID",
                table: "userCartItem");

            migrationBuilder.DropColumn(
                name: "fk_temID",
                table: "userCartItem");

            migrationBuilder.RenameColumn(
                name: "ItemPackageID",
                table: "userCartItem",
                newName: "ItemPackageId");

            migrationBuilder.AlterColumn<decimal>(
                name: "PackageId",
                table: "userCartItem",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<string>(
                name: "MainImgUrl",
                table: "CategorItem",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImgUrl",
                table: "CategorItem");

            migrationBuilder.RenameColumn(
                name: "ItemPackageId",
                table: "userCartItem",
                newName: "ItemPackageID");

            migrationBuilder.AlterColumn<short>(
                name: "PackageId",
                table: "userCartItem",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<decimal>(
                name: "ItemBarCodeID",
                table: "userCartItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "fk_itemPackageID",
                table: "userCartItem",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "fk_temID",
                table: "userCartItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_FkItemId",
                table: "CartProducts",
                column: "FkItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Items_FkItemId",
                table: "CartProducts",
                column: "FkItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
