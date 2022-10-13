using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementMVCExample.Migrations
{
    public partial class RootDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartID",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeAdress",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SushiProductsCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Sushis",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sushis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserID = table.Column<int>(type: "int", nullable: true),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalSchema: "Identity",
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_User_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

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
                name: "IX_User_CartID",
                schema: "Identity",
                table: "User",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartSushi_SushisId",
                schema: "Identity",
                table: "CartSushi",
                column: "SushisId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Identity",
                table: "Orders",
                column: "CustomerId");

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
                name: "FK_User_Carts_CartID",
                schema: "Identity",
                table: "User",
                column: "CartID",
                principalSchema: "Identity",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Carts_CartID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropTable(
                name: "CartSushi",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Sushis",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_User_CartID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CartID",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HomeAdress",
                schema: "Identity",
                table: "User");
        }
    }
}
