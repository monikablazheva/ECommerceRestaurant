using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class UsersFavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_ApplicationUserId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ApplicationUserProduct",
                schema: "Identity",
                columns: table => new
                {
                    FavouriteProductsId = table.Column<int>(type: "int", nullable: false),
                    UsersFavouriteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProduct", x => new { x.FavouriteProductsId, x.UsersFavouriteId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_Products_FavouriteProductsId",
                        column: x => x.FavouriteProductsId,
                        principalSchema: "Identity",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_User_UsersFavouriteId",
                        column: x => x.UsersFavouriteId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProduct_UsersFavouriteId",
                schema: "Identity",
                table: "ApplicationUserProduct",
                column: "UsersFavouriteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProduct",
                schema: "Identity");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                schema: "Identity",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_ApplicationUserId",
                schema: "Identity",
                table: "Products",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
