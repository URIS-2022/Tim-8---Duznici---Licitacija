using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DueDates",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DueDates", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LeaseAgreements",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuaranteeType = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateRecording = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinisterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeadlineLandReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfSigning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfSigning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentStatus = table.Column<int>(type: "int", nullable: false),
                    DueDateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseAgreements", x => x.Guid);
                    table.UniqueConstraint("AK_LeaseAgreements_PersonGuid", x => x.PersonGuid);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_DueDates_DueDateGuid",
                        column: x => x.DueDateGuid,
                        principalTable: "DueDates",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealisedArea = table.Column<int>(type: "int", nullable: false),
                    Ban = table.Column<bool>(type: "bit", nullable: false),
                    StartDateOfBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BanDuration = table.Column<int>(type: "int", nullable: false),
                    BanEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Priorities = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Buyers_LeaseAgreements_PersonGuid",
                        column: x => x.PersonGuid,
                        principalTable: "LeaseAgreements",
                        principalColumn: "PersonGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateSubbmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    LeaseAgreementGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Documents_LeaseAgreements_LeaseAgreementGuid",
                        column: x => x.LeaseAgreementGuid,
                        principalTable: "LeaseAgreements",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_PersonGuid",
                table: "Buyers",
                column: "PersonGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LeaseAgreementGuid",
                table: "Documents",
                column: "LeaseAgreementGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceNumber",
                table: "Documents",
                column: "ReferenceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_DueDateGuid",
                table: "LeaseAgreements",
                column: "DueDateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_ReferenceNumber",
                table: "LeaseAgreements",
                column: "ReferenceNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LeaseAgreements");

            migrationBuilder.DropTable(
                name: "DueDates");
        }
    }
}
