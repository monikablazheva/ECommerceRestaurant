using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class OrderCartRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "Identity",
                table: "Sushis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                schema: "Identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                schema: "Identity",
                table: "Orders",
                column: "CartID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartID",
                schema: "Identity",
                table: "Orders",
                column: "CartID",
                principalSchema: "Identity",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "Identity",
                table: "Sushis");

            migrationBuilder.DropColumn(
                name: "CartID",
                schema: "Identity",
                table: "Orders");
        }
    }
}
