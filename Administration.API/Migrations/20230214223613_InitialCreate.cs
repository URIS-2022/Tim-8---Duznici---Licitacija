using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Administration.API.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Committees",
            columns: table => new
            {
                Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                DateAssembled = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Committees", x => x.Guid);
            });

        migrationBuilder.CreateTable(
            name: "Documents",
            columns: table => new
            {
                Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Type = table.Column<int>(type: "int", nullable: false),
                DocumentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DateSubbmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                DateCertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                Template = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Documents", x => x.Guid);
            });

        migrationBuilder.CreateTable(
            name: "Members",
            columns: table => new
            {
                Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Members", x => x.Guid);
            });

        migrationBuilder.CreateTable(
            name: "CommitteeMembers",
            columns: table => new
            {
                CommitteeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MemberGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CommitteeMembers", x => new { x.CommitteeGuid, x.MemberGuid });
                table.ForeignKey(
                    name: "FK_CommitteeMembers_Committees_CommitteeGuid",
                    column: x => x.CommitteeGuid,
                    principalTable: "Committees",
                    principalColumn: "Guid",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CommitteeMembers_Members_MemberGuid",
                    column: x => x.MemberGuid,
                    principalTable: "Members",
                    principalColumn: "Guid",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Committees",
            columns: new[] { "Guid", "DateAssembled" },
            values: new object[] { new Guid("42afdb31-0568-4a14-92e1-9430d7c819c9"), new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Local) });

        migrationBuilder.InsertData(
            table: "Members",
            columns: new[] { "Guid", "FirstName", "LastName" },
            values: new object[] { new Guid("9eab25c2-0a43-47d7-bf7b-912871e76df6"), "Mike", "Joa" });

        migrationBuilder.InsertData(
            table: "CommitteeMembers",
            columns: new[] { "CommitteeGuid", "MemberGuid", "Role" },
            values: new object[] { new Guid("42afdb31-0568-4a14-92e1-9430d7c819c9"), new Guid("9eab25c2-0a43-47d7-bf7b-912871e76df6"), "ab" });

        migrationBuilder.CreateIndex(
            name: "IX_CommitteeMembers_MemberGuid",
            table: "CommitteeMembers",
            column: "MemberGuid");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CommitteeMembers");

        migrationBuilder.DropTable(
            name: "Documents");

        migrationBuilder.DropTable(
            name: "Committees");

        migrationBuilder.DropTable(
            name: "Members");
    }
}
