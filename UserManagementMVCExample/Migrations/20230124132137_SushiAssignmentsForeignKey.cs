using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class SushiAssignmentsForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Product_SushiID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Product_SushiID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "SushiID",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Product_SushiID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Product_SushiID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "SushiID",
                principalSchema: "Identity",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
