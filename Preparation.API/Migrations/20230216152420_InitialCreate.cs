using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Preparation.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnouncementGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Documents_Announcements_AnnouncementGuid",
                        column: x => x.AnnouncementGuid,
                        principalTable: "Announcements",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Guid", "LicitationGuid" },
                values: new object[,]
                {
                    { new Guid("8da0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-2002-3df21b91a0bb") },
                    { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-1001-3df21b91a0bb") }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Guid", "AnnouncementGuid", "DateCertified", "DateSubmitted", "DocumentStatus", "DocumentType", "ReferenceNumber", "Template" },
                values: new object[,]
                {
                    { new Guid("8de0c01b-b4b0-4df2-9009-3df21b91a0bb"), new Guid("8da0c01b-b7b0-4df2-9009-3df21b91a0bb"), new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "34432564789541299211", "Sablon dokumenta" },
                    { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "34432564789541231211", "Sablon dokumenta" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AnnouncementGuid",
                table: "Documents",
                column: "AnnouncementGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceNumber",
                table: "Documents",
                column: "ReferenceNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Announcements");
        }
    }
}
