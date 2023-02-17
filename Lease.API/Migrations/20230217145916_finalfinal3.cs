using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class finalfinal3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Buyers_PersonGuid",
                table: "Buyers");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_PersonGuid",
                table: "Buyers",
                column: "PersonGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Buyers_PersonGuid",
                table: "Buyers");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_PersonGuid",
                table: "Buyers",
                column: "PersonGuid",
                unique: true);
        }
    }
}
