using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class DeleteImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageURL",
                schema: "Identity",
                table: "Sushis",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageURL",
                schema: "Identity",
                table: "Desserts",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageURL",
                schema: "Identity",
                table: "Combos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageURL",
                schema: "Identity",
                table: "Beverages",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
