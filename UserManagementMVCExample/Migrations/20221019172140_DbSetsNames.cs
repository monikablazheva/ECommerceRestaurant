using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class DbSetsNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeverageCart_Beverage_BeveragesId",
                schema: "Identity",
                table: "BeverageCart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDessert_Dessert_DessertsId",
                schema: "Identity",
                table: "CartDessert");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboSushi_Combo_CombosId",
                schema: "Identity",
                table: "ComboSushi");

            migrationBuilder.DropTable(
                name: "SushiAssignment",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dessert",
                schema: "Identity",
                table: "Dessert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Combo",
                schema: "Identity",
                table: "Combo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beverage",
                schema: "Identity",
                table: "Beverage");

            migrationBuilder.RenameTable(
                name: "Dessert",
                schema: "Identity",
                newName: "Desserts",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Combo",
                schema: "Identity",
                newName: "Combos",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Beverage",
                schema: "Identity",
                newName: "Beverages",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Desserts",
                schema: "Identity",
                table: "Desserts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Combos",
                schema: "Identity",
                table: "Combos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beverages",
                schema: "Identity",
                table: "Beverages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SushiAssignmentViewModel",
                schema: "Identity",
                columns: table => new
                {
                    ComboID = table.Column<int>(type: "int", nullable: false),
                    SushiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SushiAssignmentViewModel", x => new { x.SushiID, x.ComboID });
                    table.ForeignKey(
                        name: "FK_SushiAssignmentViewModel_Combos_ComboID",
                        column: x => x.ComboID,
                        principalSchema: "Identity",
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SushiAssignmentViewModel_Sushis_SushiID",
                        column: x => x.SushiID,
                        principalSchema: "Identity",
                        principalTable: "Sushis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SushiAssignmentViewModel_ComboID",
                schema: "Identity",
                table: "SushiAssignmentViewModel",
                column: "ComboID");

            migrationBuilder.AddForeignKey(
                name: "FK_BeverageCart_Beverages_BeveragesId",
                schema: "Identity",
                table: "BeverageCart",
                column: "BeveragesId",
                principalSchema: "Identity",
                principalTable: "Beverages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDessert_Desserts_DessertsId",
                schema: "Identity",
                table: "CartDessert",
                column: "DessertsId",
                principalSchema: "Identity",
                principalTable: "Desserts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboSushi_Combos_CombosId",
                schema: "Identity",
                table: "ComboSushi",
                column: "CombosId",
                principalSchema: "Identity",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeverageCart_Beverages_BeveragesId",
                schema: "Identity",
                table: "BeverageCart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDessert_Desserts_DessertsId",
                schema: "Identity",
                table: "CartDessert");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboSushi_Combos_CombosId",
                schema: "Identity",
                table: "ComboSushi");

            migrationBuilder.DropTable(
                name: "SushiAssignmentViewModel",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Desserts",
                schema: "Identity",
                table: "Desserts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Combos",
                schema: "Identity",
                table: "Combos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beverages",
                schema: "Identity",
                table: "Beverages");

            migrationBuilder.RenameTable(
                name: "Desserts",
                schema: "Identity",
                newName: "Dessert",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Combos",
                schema: "Identity",
                newName: "Combo",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Beverages",
                schema: "Identity",
                newName: "Beverage",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dessert",
                schema: "Identity",
                table: "Dessert",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Combo",
                schema: "Identity",
                table: "Combo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beverage",
                schema: "Identity",
                table: "Beverage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SushiAssignment",
                schema: "Identity",
                columns: table => new
                {
                    SushiID = table.Column<int>(type: "int", nullable: false),
                    ComboID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SushiAssignment", x => new { x.SushiID, x.ComboID });
                    table.ForeignKey(
                        name: "FK_SushiAssignment_Combo_ComboID",
                        column: x => x.ComboID,
                        principalSchema: "Identity",
                        principalTable: "Combo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SushiAssignment_Sushis_SushiID",
                        column: x => x.SushiID,
                        principalSchema: "Identity",
                        principalTable: "Sushis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SushiAssignment_ComboID",
                schema: "Identity",
                table: "SushiAssignment",
                column: "ComboID");

            migrationBuilder.AddForeignKey(
                name: "FK_BeverageCart_Beverage_BeveragesId",
                schema: "Identity",
                table: "BeverageCart",
                column: "BeveragesId",
                principalSchema: "Identity",
                principalTable: "Beverage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDessert_Dessert_DessertsId",
                schema: "Identity",
                table: "CartDessert",
                column: "DessertsId",
                principalSchema: "Identity",
                principalTable: "Dessert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboSushi_Combo_CombosId",
                schema: "Identity",
                table: "ComboSushi",
                column: "CombosId",
                principalSchema: "Identity",
                principalTable: "Combo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
