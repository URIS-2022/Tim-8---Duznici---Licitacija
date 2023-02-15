using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class push4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_DueDates_DueDateId",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_DueDateId",
                table: "LeaseAgreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DueDates",
                table: "DueDates");

            migrationBuilder.DropColumn(
                name: "DueDateId",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DueDates");

            migrationBuilder.AddColumn<Guid>(
                name: "DueDateGuid",
                table: "LeaseAgreements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "DueDates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DueDates",
                table: "DueDates",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_DueDateGuid",
                table: "LeaseAgreements",
                column: "DueDateGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_DueDates_DueDateGuid",
                table: "LeaseAgreements",
                column: "DueDateGuid",
                principalTable: "DueDates",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaseAgreements_DueDates_DueDateGuid",
                table: "LeaseAgreements");

            migrationBuilder.DropIndex(
                name: "IX_LeaseAgreements_DueDateGuid",
                table: "LeaseAgreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DueDates",
                table: "DueDates");

            migrationBuilder.DropColumn(
                name: "DueDateGuid",
                table: "LeaseAgreements");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "DueDates");

            migrationBuilder.AddColumn<int>(
                name: "DueDateId",
                table: "LeaseAgreements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DueDates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DueDates",
                table: "DueDates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_DueDateId",
                table: "LeaseAgreements",
                column: "DueDateId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaseAgreements_DueDates_DueDateId",
                table: "LeaseAgreements",
                column: "DueDateId",
                principalTable: "DueDates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
