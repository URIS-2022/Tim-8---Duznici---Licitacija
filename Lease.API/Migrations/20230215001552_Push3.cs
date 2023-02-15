using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class Push3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DueDates_LeaseAgreements_LeaseAgreementGuid",
                table: "DueDates");

            migrationBuilder.DropIndex(
                name: "IX_DueDates_LeaseAgreementGuid",
                table: "DueDates");

            migrationBuilder.DropColumn(
                name: "LeaseAgreementGuid",
                table: "DueDates");

            migrationBuilder.AddColumn<int>(
                name: "DocumentStatus",
                table: "LeaseAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DueDateId",
                table: "LeaseAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuaranteeType",
                table: "LeaseAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PriorityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityTypeEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriorityTypes_PriorityTypes_PriorityTypeEntityId",
                        column: x => x.PriorityTypeEntityId,
                        principalTable: "PriorityTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriorityBuyers",
                columns: table => new
                {
                    BuyerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorityTypeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityBuyers", x => new { x.BuyerGuid, x.PriorityTypeId });
                    table.ForeignKey(
                        name: "FK_PriorityBuyers_Buyers_BuyerGuid",
                        column: x => x.BuyerGuid,
                        principalTable: "Buyers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriorityBuyers_PriorityTypes_PriorityTypeId",
                        column: x => x.PriorityTypeId,
                        principalTable: "PriorityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_DueDateId",
                table: "LeaseAgreements",
                column: "DueDateId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorityBuyers_PriorityTypeId",
                table: "PriorityBuyers",
                column: "PriorityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorityTypes_PriorityTypeEntityId",
                table: "PriorityTypes",
                column: "PriorityTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_DueDates_DueDateId",
                table: "LeaseAgreements",
                column: "DueDateId",
                principalTable: "DueDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_DueDates_DueDateId",
                table: "LeaseAgreements");

            migrationBuilder.DropTable(
                name: "PriorityBuyers");

            migrationBuilder.DropTable(
                name: "PriorityTypes");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_DueDateId",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "DueDateId",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "GuaranteeType",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaseAgreementGuid",
                table: "DueDates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DueDates_LeaseAgreementGuid",
                table: "DueDates",
                column: "LeaseAgreementGuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DueDates_LeaseAgreements_LeaseAgreementGuid",
                table: "DueDates",
                column: "LeaseAgreementGuid",
                principalTable: "LeaseAgreements",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
