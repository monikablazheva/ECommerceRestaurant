using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class SushiAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignmentViewModel_Combos_ComboID",
                schema: "Identity",
                table: "SushiAssignmentViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignmentViewModel_Sushis_SushiID",
                schema: "Identity",
                table: "SushiAssignmentViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SushiAssignmentViewModel",
                schema: "Identity",
                table: "SushiAssignmentViewModel");

            migrationBuilder.RenameTable(
                name: "SushiAssignmentViewModel",
                schema: "Identity",
                newName: "SushiAssignments",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_SushiAssignmentViewModel_ComboID",
                schema: "Identity",
                table: "SushiAssignments",
                newName: "IX_SushiAssignments_ComboID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SushiAssignments",
                schema: "Identity",
                table: "SushiAssignments",
                columns: new[] { "SushiID", "ComboID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Combos_ComboID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "ComboID",
                principalSchema: "Identity",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignments_Sushis_SushiID",
                schema: "Identity",
                table: "SushiAssignments",
                column: "SushiID",
                principalSchema: "Identity",
                principalTable: "Sushis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Combos_ComboID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_SushiAssignments_Sushis_SushiID",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SushiAssignments",
                schema: "Identity",
                table: "SushiAssignments");

            migrationBuilder.RenameTable(
                name: "SushiAssignments",
                schema: "Identity",
                newName: "SushiAssignmentViewModel",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_SushiAssignments_ComboID",
                schema: "Identity",
                table: "SushiAssignmentViewModel",
                newName: "IX_SushiAssignmentViewModel_ComboID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SushiAssignmentViewModel",
                schema: "Identity",
                table: "SushiAssignmentViewModel",
                columns: new[] { "SushiID", "ComboID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignmentViewModel_Combos_ComboID",
                schema: "Identity",
                table: "SushiAssignmentViewModel",
                column: "ComboID",
                principalSchema: "Identity",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SushiAssignmentViewModel_Sushis_SushiID",
                schema: "Identity",
                table: "SushiAssignmentViewModel",
                column: "SushiID",
                principalSchema: "Identity",
                principalTable: "Sushis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
