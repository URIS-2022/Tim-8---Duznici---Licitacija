using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Lots", x => new { x.LandGuid, x.LotGuid });
                });

            migrationBuilder.InsertData(
                table: "Lands",
                columns: new[] { "LandGuid", "Drainage", "LandClass", "LandCulture", "LandProcessing", "Municipality", "MunicipalityId", "PropertyType", "ProtectedZone", "RealEstateNumber", "TotalArea" },
                values: new object[] { new Guid("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), "Excellent", "1", "Field", "Arable", "Bajmok", new Guid("aa3f2265-7182-4424-ba83-2eed388ce748"), "Private", "III", "2", 3000 });

            migrationBuilder.InsertData(
                table: "Lots",
                columns: new[] { "LandGuid", "LotGuid", "DrainageState", "LandCultureState", "LandProcessingState", "LotArea", "LotNumber", "LotUser", "ProtectedZoneState" },
                values: new object[] { new Guid("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"), new Guid("67e0bcc7-db55-4726-8b3d-ee0dabed6de3"), "Good", "Field", "Arable", 1234, 1, "John Doe", "II" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "Lots");
        }
    }
}
