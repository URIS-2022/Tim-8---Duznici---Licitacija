using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bidding.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdateDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PublicBiddings",
                keyColumn: "Guid",
                keyValue: new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                column: "public_bidding_type",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PublicBiddings",
                keyColumn: "Guid",
                keyValue: new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                column: "public_bidding_type",
                value: 0);
        }
    }
}
