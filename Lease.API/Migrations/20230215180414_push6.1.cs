using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lease.API.Migrations
{
    /// <inheritdoc />
    public partial class push61 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentGuid",
                table: "Buyers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentGuid",
                table: "Buyers",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
