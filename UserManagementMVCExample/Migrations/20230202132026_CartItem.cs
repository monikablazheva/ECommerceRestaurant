using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class CartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_SushiId",
                schema: "Identity",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Product_ProductId",
                schema: "Identity",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_Beverage_CartId",
                schema: "Identity",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                schema: "Identity",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Product_ComboID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Product_SushiID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "Identity",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Identity",
                newName: "Products",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CartId",
                schema: "Identity",
                table: "Products",
                newName: "IX_Products_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Beverage_CartId",
                schema: "Identity",
                table: "Products",
                newName: "IX_Products_Beverage_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                schema: "Identity",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                schema: "Identity",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_SushiId",
                schema: "Identity",
                table: "Cart",
                column: "SushiId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                schema: "Identity",
                table: "CartItems",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cart_Beverage_CartId",
                schema: "Identity",
                table: "Products",
                column: "Beverage_CartId",
                principalSchema: "Identity",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cart_CartId",
                schema: "Identity",
                table: "Products",
                column: "CartId",
                principalSchema: "Identity",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Products_ComboID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "ComboID",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Products_SushiID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "SushiID",
                principalSchema: "Identity",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_SushiId",
                schema: "Identity",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                schema: "Identity",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_Beverage_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Products_ComboID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Products_SushiID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                schema: "Identity",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Identity",
                newName: "Product",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CartId",
                schema: "Identity",
                table: "Product",
                newName: "IX_Product_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Beverage_CartId",
                schema: "Identity",
                table: "Product",
                newName: "IX_Product_Beverage_CartId");

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                schema: "Identity",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "Identity",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_SushiId",
                schema: "Identity",
                table: "Cart",
                column: "SushiId",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Product_ProductId",
                schema: "Identity",
                table: "CartItems",
                column: "ProductId",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_Beverage_CartId",
                schema: "Identity",
                table: "Product",
                column: "Beverage_CartId",
                principalSchema: "Identity",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                schema: "Identity",
                table: "Product",
                column: "CartId",
                principalSchema: "Identity",
                principalTable: "Cart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Product_ComboID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "ComboID",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Product_SushiID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "SushiID",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
