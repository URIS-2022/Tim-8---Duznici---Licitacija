using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "SystemUsers",
            columns: table => new
            {
                Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Role = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SystemUsers", x => x.Guid);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SystemUsers_Username",
            table: "SystemUsers",
            column: "Username",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SystemUsers");
    }
}
