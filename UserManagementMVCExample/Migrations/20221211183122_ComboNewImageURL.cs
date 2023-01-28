using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class ComboNewImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                schema: "Identity",
                table: "Combos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageURL",
                schema: "Identity",
                table: "Combos",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
