using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class ComboImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ComboImageURL",
                schema: "Identity",
                table: "Combos",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
