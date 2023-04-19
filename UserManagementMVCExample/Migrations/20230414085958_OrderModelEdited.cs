using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class OrderModelEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_CustomerId",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                schema: "Identity",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTime",
                schema: "Identity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_CustomerId",
                schema: "Identity",
                table: "Orders",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_CustomerId",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                schema: "Identity",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                schema: "Identity",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                schema: "Identity",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                schema: "Identity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_User_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentID",
                schema: "Identity",
                table: "Orders",
                column: "PaymentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                schema: "Identity",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentID",
                schema: "Identity",
                table: "Orders",
                column: "PaymentID",
                principalSchema: "Identity",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_CustomerId",
                schema: "Identity",
                table: "Orders",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
