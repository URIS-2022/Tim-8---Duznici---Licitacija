using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Person.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ContactPersons",
                columns: table => new
                {
                    ContactPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPersons", x => x.ContactPersonId);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersons",
                columns: table => new
                {
                    PhysicalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jmbg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersons", x => x.PhysicalPersonId);
                    table.ForeignKey(
                        name: "FK_PhysicalPersons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersons",
                columns: table => new
                {
                    LegalPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersons", x => x.LegalPersonId);
                    table.ForeignKey(
                        name: "FK_LegalPersons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalPersons_ContactPersons_ContactPersonId",
                        column: x => x.ContactPersonId,
                        principalTable: "ContactPersons",
                        principalColumn: "ContactPersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Country", "Place", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { new Guid("9a8e31d5-5e7b-46e7-80c6-f22e607ee907"), 0, "Beograd", "Njegoseva", "21", "11000" });

            migrationBuilder.InsertData(
                table: "ContactPersons",
                columns: new[] { "ContactPersonId", "FirstName", "Function", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("a43a31f7-ffad-4aff-a199-1a6d31a8b850"), "Petar", "Generalni direktor", "Milanovic", "0639444271" });

            migrationBuilder.InsertData(
                table: "LegalPersons",
                columns: new[] { "LegalPersonId", "AccountNumber", "AddressId", "ContactPersonId", "Email", "Fax", "IdentificationNumber", "Name", "PhoneNumber1", "PhoneNumber2" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), "7654321", new Guid("9a8e31d5-5e7b-46e7-80c6-f22e607ee907"), new Guid("a43a31f7-ffad-4aff-a199-1a6d31a8b850"), "vaskons@yahoo.com", "1110222", "16050", "Vaskons", "0613263358", "0603377409" });

            migrationBuilder.InsertData(
                table: "PhysicalPersons",
                columns: new[] { "PhysicalPersonId", "AccountNumber", "AddressId", "Email", "FirstName", "Jmbg", "LastName", "PhoneNumber1", "PhoneNumber2" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), "1234567", new Guid("9a8e31d5-5e7b-46e7-80c6-f22e607ee907"), "luka123@gmail.com", "Luka", "1234567876543", "Lukic", "0652632633", "0622402001" });

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersons_AddressId",
                table: "LegalPersons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersons_ContactPersonId",
                table: "LegalPersons",
                column: "ContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersons_AddressId",
                table: "PhysicalPersons",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalPersons");

            migrationBuilder.DropTable(
                name: "PhysicalPersons");

            migrationBuilder.DropTable(
                name: "ContactPersons");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
