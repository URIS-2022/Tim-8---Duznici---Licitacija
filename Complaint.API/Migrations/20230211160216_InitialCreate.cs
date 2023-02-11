using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Complaint.API.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Complaints",
            columns: table => new
            {
                Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Type = table.Column<int>(type: "int", nullable: false),
                DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                BuyerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Rationale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ResolutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ResolutionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                SubjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Action = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Complaints", x => x.Guid);
            });

        migrationBuilder.InsertData(
            table: "Complaints",
            columns: new[] { "Guid", "Action", "BuyerGuid", "DateSubmitted", "Rationale", "Reason", "ResolutionCode", "ResolutionDate", "Status", "SubjectGuid", "Type" },
            values: new object[] { new Guid("1d2d5ce3-596e-4246-9f92-d5a8814c4fdb"), 1, new Guid("63abde59-1ea0-455f-91ab-d179029a1e39"), new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Local), "Ono je test podatak", "Nema razloga", "F86S8OLFD", new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Local), 0, new Guid("eda5afb2-a4d1-4d19-b6d5-a988d32513d2"), 2 });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Complaints");
    }
}
