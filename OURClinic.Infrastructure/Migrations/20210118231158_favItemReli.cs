using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OURCart.Infrastructure.Migrations
{
    public partial class favItemReli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     
     

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    FkItemId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    fkPackageID = table.Column<decimal>(type: "numeric(18, 0)", nullable: false),
                    insertDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    fk_itemBarCodeID = table.Column<decimal>(nullable: true),
                    fk_DeliveryClientId = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartProducts_Items",
                        column: x => x.FkItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

       

     
            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_FkItemId",
                table: "CartProducts",
                column: "FkItemId");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
