using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class push6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentGuid",
                table: "Buyers",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentGuid",
                table: "Buyers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "jsonb");
        }
    }
}
