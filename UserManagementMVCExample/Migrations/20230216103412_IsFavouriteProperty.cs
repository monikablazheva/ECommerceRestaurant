using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class IsFavouriteProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cart_CartID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_Beverage_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Cart_CartID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "Cart",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_User_CartID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Products_Beverage_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Beverage_CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                schema: "Identity",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavourite",
                schema: "Identity",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Beverage_CartId",
                schema: "Identity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                schema: "Identity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                schema: "Identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cart",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SushiId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserID = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SushiProductsCount = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Products_SushiId",
                        column: x => x.SushiId,
                        principalSchema: "Identity",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CartID",
                schema: "Identity",
                table: "User",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Beverage_CartId",
                schema: "Identity",
                table: "Products",
                column: "Beverage_CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartId",
                schema: "Identity",
                table: "Products",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                schema: "Identity",
                table: "Orders",
                column: "CartID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_SushiId",
                schema: "Identity",
                table: "Cart",
                column: "SushiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cart_CartID",
                schema: "Identity",
                table: "Orders",
                column: "CartID",
                principalSchema: "Identity",
                principalTable: "Cart",
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
                name: "FK_User_Cart_CartID",
                schema: "Identity",
                table: "User",
                column: "CartID",
                principalSchema: "Identity",
                principalTable: "Cart",
                principalColumn: "Id");
        }
    }
}
