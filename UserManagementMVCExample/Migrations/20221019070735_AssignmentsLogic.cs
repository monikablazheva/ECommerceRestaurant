using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class AssignmentsLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SushiAssignment",
                schema: "Identity",
                columns: table => new
                {
                    ComboID = table.Column<int>(type: "int", nullable: false),
                    SushiID = table.Column<int>(type: "int", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SushiAssignment",
                schema: "Identity");
        }
    }
}
