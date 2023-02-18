﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Licitation.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicitationEntities",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stage = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Constarint = table.Column<int>(type: "int", nullable: false),
                    BidIncrement = table.Column<int>(type: "int", nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitationEntities", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Documents_LicitationEntities_LicitationGuid",
                        column: x => x.LicitationGuid,
                        principalTable: "LicitationEntities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicitationLands",
                columns: table => new
                {
                    LicitationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitationGuid1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitationLands", x => new { x.LandGuid, x.LicitationGuid });
                    table.ForeignKey(
                        name: "FK_LicitationLands_LicitationEntities_LicitationGuid",
                        column: x => x.LicitationGuid,
                        principalTable: "LicitationEntities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicitationLands_LicitationEntities_LicitationGuid1",
                        column: x => x.LicitationGuid1,
                        principalTable: "LicitationEntities",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LicitationPublicBiddings",
                columns: table => new
                {
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitationGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicitationGuid1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicitationPublicBiddings", x => new { x.PublicBiddingGuid, x.LicitationGuid });
                    table.ForeignKey(
                        name: "FK_LicitationPublicBiddings_LicitationEntities_LicitationGuid",
                        column: x => x.LicitationGuid,
                        principalTable: "LicitationEntities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicitationPublicBiddings_LicitationEntities_LicitationGuid1",
                        column: x => x.LicitationGuid1,
                        principalTable: "LicitationEntities",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_LicitationGuid",
                table: "Documents",
                column: "LicitationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceNumber",
                table: "Documents",
                column: "ReferenceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicitationLands_LicitationGuid",
                table: "LicitationLands",
                column: "LicitationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LicitationLands_LicitationGuid1",
                table: "LicitationLands",
                column: "LicitationGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_LicitationPublicBiddings_LicitationGuid",
                table: "LicitationPublicBiddings",
                column: "LicitationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LicitationPublicBiddings_LicitationGuid1",
                table: "LicitationPublicBiddings",
                column: "LicitationGuid1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LicitationLands");

            migrationBuilder.DropTable(
                name: "LicitationPublicBiddings");

            migrationBuilder.DropTable(
                name: "LicitationEntities");
        }
    }
}