using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DueDates",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDateGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateRecording = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinisterGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeadlineLandReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfSigning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfSigning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    Priorities = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateSubbmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "DueDates",
                columns: new[] { "Guid", "Date", "DueDateGuid" },
                values: new object[] { new Guid("b415d4f5-6342-41f3-9935-08db10fc223b"), new DateTime(2023, 1, 17, 15, 32, 2, 236, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "LeaseAgreements",
                columns: new[] { "Guid", "DateOfSigning", "DateRecording", "DeadlineLandReturn", "DocumentStatus", "DueDateGuid", "GuaranteeType", "MinisterGuid", "PersonGuid", "PlaceOfSigning", "PublicBiddingGuid", "ReferenceNumber" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2023, 2, 18, 17, 18, 11, 961, DateTimeKind.Local), new DateTime(2023, 2, 18, 17, 18, 11, 961, DateTimeKind.Local), new DateTime(2023, 2, 18, 17, 18, 11, 961, DateTimeKind.Local), 0, new Guid("b415d4f5-6342-41f3-9935-08db10fc223b"), 0, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "string", new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "string" });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "Guid", "Ban", "BanDuration", "BanEndDate", "BiddingGuid", "PersonGuid", "Priorities", "RealisedArea", "StartDateOfBan" },
                values: new object[] { new Guid("600f70cc-2384-4ea7-95fa-9ef269736e3f"), false, 0, new DateTime(2023, 2, 17, 16, 33, 22, 979, DateTimeKind.Local), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "[2,1]", 20, new DateTime(2023, 2, 17, 16, 33, 22, 979, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Guid", "DateCertified", "DateSubbmitted", "LeaseAgreementGuid", "ReferenceNumber", "Template", "Type" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new DateTime(2023, 2, 17, 15, 35, 11, 651, DateTimeKind.Utc), new DateTime(2023, 2, 17, 15, 35, 11, 651, DateTimeKind.Utc), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "lll", "SV obrazac", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_PersonGuid",
                table: "Buyers",
                column: "PersonGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LeaseAgreementGuid",
                table: "Documents",
                column: "LeaseAgreementGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceNumber",
                table: "Documents",
                column: "ReferenceNumber",
                unique: true,
                filter: "[ReferenceNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_DueDateGuid",
                table: "LeaseAgreements",
                column: "DueDateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_ReferenceNumber",
                table: "LeaseAgreements",
                column: "ReferenceNumber",
                unique: true,
                filter: "[ReferenceNumber] IS NOT NULL");
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
