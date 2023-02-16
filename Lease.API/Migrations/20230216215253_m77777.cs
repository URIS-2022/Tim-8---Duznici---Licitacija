using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class m77777 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "Documents",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "DateSubmissed",
                table: "Documents",
                newName: "DateSubbmitted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Documents",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "DateSubbmitted",
                table: "Documents",
                newName: "DateSubmissed");
        }
    }
}
