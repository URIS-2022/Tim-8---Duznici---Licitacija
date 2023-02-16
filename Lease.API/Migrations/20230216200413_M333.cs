using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class M333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriorityTypeEntity");

            migrationBuilder.AddColumn<string>(
                name: "Priorities",
                table: "Buyers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priorities",
                table: "Buyers");

            migrationBuilder.CreateTable(
                name: "PriorityTypeEntity",
                columns: table => new
                {
                    BuyerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorityTypes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityTypeEntity", x => new { x.BuyerGuid, x.Id });
                    table.ForeignKey(
                        name: "FK_PriorityTypeEntity_Buyers_BuyerGuid",
                        column: x => x.BuyerGuid,
                        principalTable: "Buyers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
