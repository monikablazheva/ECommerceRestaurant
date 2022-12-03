using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class ImageURLsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                schema: "Identity",
                table: "Sushis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                schema: "Identity",
                table: "Desserts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                schema: "Identity",
                table: "Combos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                schema: "Identity",
                table: "Beverages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                schema: "Identity",
                table: "Sushis");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                schema: "Identity",
                table: "Desserts");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                schema: "Identity",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                schema: "Identity",
                table: "Beverages");
        }
    }
}
