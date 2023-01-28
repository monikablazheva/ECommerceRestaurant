using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class AddStringCartID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartId",
                schema: "Identity",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                schema: "Identity",
                table: "Carts");
        }
    }
}
