using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class OrdersItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItem_Orders_OrderId",
                schema: "Identity",
                table: "OrdersItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItem_Products_ProductId",
                schema: "Identity",
                table: "OrdersItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersItem",
                schema: "Identity",
                table: "OrdersItem");

            migrationBuilder.RenameTable(
                name: "OrdersItem",
                schema: "Identity",
                newName: "OrdersItems",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItem_ProductId",
                schema: "Identity",
                table: "OrdersItems",
                newName: "IX_OrdersItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItem_OrderId",
                schema: "Identity",
                table: "OrdersItems",
                newName: "IX_OrdersItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersItems",
                schema: "Identity",
                table: "OrdersItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                schema: "Identity",
                table: "OrdersItems",
                column: "OrderId",
                principalSchema: "Identity",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                schema: "Identity",
                table: "OrdersItems",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Orders_OrderId",
                schema: "Identity",
                table: "OrdersItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersItems_Products_ProductId",
                schema: "Identity",
                table: "OrdersItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersItems",
                schema: "Identity",
                table: "OrdersItems");

            migrationBuilder.RenameTable(
                name: "OrdersItems",
                schema: "Identity",
                newName: "OrdersItem",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItems_ProductId",
                schema: "Identity",
                table: "OrdersItem",
                newName: "IX_OrdersItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersItems_OrderId",
                schema: "Identity",
                table: "OrdersItem",
                newName: "IX_OrdersItem_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersItem",
                schema: "Identity",
                table: "OrdersItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItem_Orders_OrderId",
                schema: "Identity",
                table: "OrdersItem",
                column: "OrderId",
                principalSchema: "Identity",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersItem_Products_ProductId",
                schema: "Identity",
                table: "OrdersItem",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
