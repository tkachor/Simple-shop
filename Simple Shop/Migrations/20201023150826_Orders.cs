using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simple_Shop.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItems",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                newName: "IX_CartItems_productId");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OrderTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    Price = table.Column<long>(nullable: false),
                    ProductId1 = table.Column<int>(nullable: true),
                    OrdeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrdeId",
                        column: x => x.OrdeId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrdeId",
                table: "OrderDetail",
                column: "OrdeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId1",
                table: "OrderDetail",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Product_productId",
                table: "CartItems",
                column: "productId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Product_productId",
                table: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "CartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_productId",
                table: "CartItems",
                newName: "IX_CartItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
