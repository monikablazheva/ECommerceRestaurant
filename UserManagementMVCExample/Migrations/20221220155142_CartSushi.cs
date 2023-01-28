using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class CartSushi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartSushi",
                schema: "Identity");

            migrationBuilder.AddColumn<int>(
                name: "SushiId",
                schema: "Identity",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SushiId",
                schema: "Identity",
                table: "Carts",
                column: "SushiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Sushis_SushiId",
                schema: "Identity",
                table: "Carts",
                column: "SushiId",
                principalSchema: "Identity",
                principalTable: "Sushis",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Sushis_SushiId",
                schema: "Identity",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_SushiId",
                schema: "Identity",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "SushiId",
                schema: "Identity",
                table: "Carts");

            migrationBuilder.CreateTable(
                name: "CartSushi",
                schema: "Identity",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    SushisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSushi", x => new { x.CartsId, x.SushisId });
                    table.ForeignKey(
                        name: "FK_CartSushi_Carts_CartsId",
                        column: x => x.CartsId,
                        principalSchema: "Identity",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartSushi_Sushis_SushisId",
                        column: x => x.SushisId,
                        principalSchema: "Identity",
                        principalTable: "Sushis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartSushi_SushisId",
                schema: "Identity",
                table: "CartSushi",
                column: "SushisId");
        }
    }
}
