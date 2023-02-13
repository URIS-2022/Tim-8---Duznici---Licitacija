using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landlot.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    LandGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Municipality = table.Column<int>(type: "int", nullable: false),
                    RealEstateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Culture = table.Column<int>(type: "int", nullable: false),
                    LandClass = table.Column<int>(type: "int", nullable: false),
                    Processing = table.Column<int>(type: "int", nullable: false),
                    Zone = table.Column<int>(type: "int", nullable: false),
                    Property = table.Column<int>(type: "int", nullable: false),
                    Drainage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.LandGuid);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    LotGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LotArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LotUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LotNumber = table.Column<int>(type: "int", nullable: false),
                    CultureState = table.Column<int>(type: "int", nullable: false),
                    ClassState = table.Column<int>(type: "int", nullable: false),
                    ProcessingState = table.Column<int>(type: "int", nullable: false),
                    ProtectedZoneState = table.Column<int>(type: "int", nullable: false),
                    DrainageState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.LotGuid);
                    table.ForeignKey(
                        name: "FK_Lots_Lands_LandGuid",
                        column: x => x.LandGuid,
                        principalTable: "Lands",
                        principalColumn: "LandGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lands",
                columns: new[] { "LandGuid", "Culture", "Drainage", "LandClass", "Municipality", "Processing", "Property", "RealEstateNumber", "TotalArea", "Zone" },
                values: new object[,]
                {
                    { new Guid("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"), 4, 0, 0, 0, 1, 0, "1234", 1111m, 4 },
                    { new Guid("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), 1, 0, 2, 1, 1, 2, "22", 300m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotGuid", "ClassState", "CultureState", "DrainageState", "LandGuid", "LotArea", "LotNumber", "LotUser", "ProcessingState", "ProtectedZoneState" },
                values: new object[,]
                {
                    { new Guid("61e0bcc1-db15-4726-8b3d-ee0dabed6de3"), 2, 0, 0, new Guid("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"), 4321.12m, 13, new Guid("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"), 0, 4 },
                    { new Guid("67e0bcc7-db55-4726-8b3d-ee0dabed6de3"), 1, 1, 0, new Guid("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), 1234.56m, 1, new Guid("3f84c3a3-34c2-48a0-93a1-f00af6c9b2bc"), 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LandGuid",
                table: "Lots",
                column: "LandGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Lands");
        }
    }
}
