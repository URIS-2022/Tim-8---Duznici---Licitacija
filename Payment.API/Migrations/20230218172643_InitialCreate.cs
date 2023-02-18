using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentWarrants",
                columns: table => new
                {
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentWarrants", x => x.ReferenceNumber);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentWarrants_ReferenceNumber",
                        column: x => x.ReferenceNumber,
                        principalTable: "PaymentWarrants",
                        principalColumn: "ReferenceNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaymentWarrants",
                columns: new[] { "ReferenceNumber", "Guid", "PayerGuid", "PublicBiddingGuid", "TotalAmount" },
                values: new object[] { "PW-1234", new Guid("e1cd0010-b413-4b81-841d-2bc234b34c85"), new Guid("ec856b7c-278d-4877-afc7-83405a3259bb"), new Guid("af3ad9df-c61c-4229-958f-e2b5f96870d7"), 100.50m });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Guid", "AccountNumber", "PayerGuid", "PaymentDate", "PaymentTitle", "PublicBiddingGuid", "ReferenceNumber", "TotalAmount" },
                values: new object[] { new Guid("56277ee2-3d28-4cde-8e6d-d2397342fc9d"), "323024329", new Guid("e31726fb-23a4-4f1b-a335-4354a96d052b"), new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Payment", new Guid("f488b81f-ff6e-4ce1-aea9-050b085b6849"), "PW-1234", 230m });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReferenceNumber",
                table: "Payments",
                column: "ReferenceNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentWarrants");
        }
    }
}
