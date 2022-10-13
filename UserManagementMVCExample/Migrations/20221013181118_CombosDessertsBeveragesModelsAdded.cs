using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class CombosDessertsBeveragesModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverage",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Milliliters = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combo",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dessert",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grams = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dessert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeverageCart",
                schema: "Identity",
                columns: table => new
                {
                    BeveragesId = table.Column<int>(type: "int", nullable: false),
                    CartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeverageCart", x => new { x.BeveragesId, x.CartsId });
                    table.ForeignKey(
                        name: "FK_BeverageCart_Beverage_BeveragesId",
                        column: x => x.BeveragesId,
                        principalSchema: "Identity",
                        principalTable: "Beverage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeverageCart_Carts_CartsId",
                        column: x => x.CartsId,
                        principalSchema: "Identity",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboSushi",
                schema: "Identity",
                columns: table => new
                {
                    CombosId = table.Column<int>(type: "int", nullable: false),
                    SushisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboSushi", x => new { x.CombosId, x.SushisId });
                    table.ForeignKey(
                        name: "FK_ComboSushi_Combo_CombosId",
                        column: x => x.CombosId,
                        principalSchema: "Identity",
                        principalTable: "Combo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboSushi_Sushis_SushisId",
                        column: x => x.SushisId,
                        principalSchema: "Identity",
                        principalTable: "Sushis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDessert",
                schema: "Identity",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    DessertsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDessert", x => new { x.CartsId, x.DessertsId });
                    table.ForeignKey(
                        name: "FK_CartDessert_Carts_CartsId",
                        column: x => x.CartsId,
                        principalSchema: "Identity",
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDessert_Dessert_DessertsId",
                        column: x => x.DessertsId,
                        principalSchema: "Identity",
                        principalTable: "Dessert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeverageCart_CartsId",
                schema: "Identity",
                table: "BeverageCart",
                column: "CartsId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDessert_DessertsId",
                schema: "Identity",
                table: "CartDessert",
                column: "DessertsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboSushi_SushisId",
                schema: "Identity",
                table: "ComboSushi",
                column: "SushisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeverageCart",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CartDessert",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ComboSushi",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Beverage",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Dessert",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Combo",
                schema: "Identity");
        }
    }
}
