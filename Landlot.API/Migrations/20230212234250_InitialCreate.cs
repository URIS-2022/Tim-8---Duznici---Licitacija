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
                    TotalArea = table.Column<int>(type: "int", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandCulture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandProcessing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtectedZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drainage = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    LotArea = table.Column<int>(type: "int", nullable: false),
                    LotUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<int>(type: "int", nullable: false),
                    LandCultureState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandProcessingState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtectedZoneState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrainageState = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "LandGuid", "Drainage", "LandClass", "LandCulture", "LandProcessing", "Municipality", "PropertyType", "ProtectedZone", "RealEstateNumber", "TotalArea" },
                values: new object[,]
                {
                    { new Guid("3f14c3a3-34c2-48a0-93a1-f00af6c9b2ba"), "Odvodnjavanje", "I", "Livade", "Ostalo", "Bikovo", "Privatna svojina", "4", "1234", 111 },
                    { new Guid("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), "Odvodnjavanje", "III", "Vrtovi", "Ostalo", "Bajmok", "Drugi oblivi", "3", "22", 3000 }
                });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LotGuid", "DrainageState", "LandCultureState", "LandGuid", "LandProcessingState", "LotArea", "LotNumber", "LotUser", "ProtectedZoneState" },
                values: new object[,]
                {
                    { new Guid("61e0bcc7-db55-4726-8b3d-ee0dabed6de3"), "Odvodnjavanje", "Njive", new Guid("3c84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), "Obradivo", 4321, 13, "Julia Roberts ", "4" },
                    { new Guid("67e0bcc7-db55-4726-8b3d-ee0dabed6de3"), "Odvodnjavanje", "Vrtovi", new Guid("3a84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), "Ostalo", 1234, 1, "John Doe", "1" }
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
