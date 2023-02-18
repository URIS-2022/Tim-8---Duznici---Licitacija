using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bidding.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PublicBiddings",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartPricePerHectar = table.Column<int>(type: "int", nullable: false),
                    Expected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    municipality = table.Column<int>(type: "int", nullable: false),
                    AuctionedPrice = table.Column<int>(type: "int", nullable: false),
                    BestBuyerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicbiddingtype = table.Column<int>(name: "public_bidding_type", type: "int", nullable: false),
                    AddresGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeasePeriod = table.Column<int>(type: "int", nullable: false),
                    DepositReplenishmentAmount = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    biddingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicBiddings", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PublicBiddings_Adresses_AddresGuid",
                        column: x => x.AddresGuid,
                        principalTable: "Adresses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    documentType = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateSubmited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSertified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Documents_PublicBiddings_PublicBiddingGuid",
                        column: x => x.PublicBiddingGuid,
                        principalTable: "PublicBiddings",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicBiddingLots",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LotGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LotNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicBiddingLots", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PublicBiddingLots_PublicBiddings_PublicBiddingGuid",
                        column: x => x.PublicBiddingGuid,
                        principalTable: "PublicBiddings",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Representatives",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfBoard = table.Column<int>(type: "int", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representatives", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Representatives_Adresses_AddressGuid",
                        column: x => x.AddressGuid,
                        principalTable: "Adresses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Representatives_PublicBiddings_PublicBiddingGuid",
                        column: x => x.PublicBiddingGuid,
                        principalTable: "PublicBiddings",
                        principalColumn: "Guid");

                });

            migrationBuilder.CreateTable(
                name: "BiddingOffers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepresentativeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicBiddingGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Offer = table.Column<float>(type: "real", nullable: false),
                    BuyerGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiddingOffers", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_BiddingOffers_PublicBiddings_PublicBiddingGuid",
                        column: x => x.PublicBiddingGuid,
                        principalTable: "PublicBiddings",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiddingOffers_Representatives_RepresentativeGuid",
                        column: x => x.RepresentativeGuid,
                        principalTable: "Representatives",
                        principalColumn: "Guid");

                });

            migrationBuilder.CreateTable(
                name: "BuyerApplications",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepresentativeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerApplications", x => new { x.Guid, x.RepresentativeGuid });
                    table.ForeignKey(
                        name: "FK_BuyerApplications_Representatives_RepresentativeGuid",
                        column: x => x.RepresentativeGuid,
                        principalTable: "Representatives",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Guid", "Country", "Place", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), "Srbija", "Subotica", "Nikole Tesle", "23", "11000" });

            migrationBuilder.InsertData(
                table: "PublicBiddings",
                columns: new[] { "Guid", "AddresGuid", "AuctionedPrice", "BestBuyerGuid", "Date", "DepositReplenishmentAmount", "EndDate", "Expected", "LeasePeriod", "Round", "StartDate", "StartPricePerHectar", "biddingStatus", "municipality", "public_bidding_type" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), 70000, new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zaboravio", 5, new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000, 1, 10, 1 });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Guid", "DateSertified", "DateSubmited", "PublicBiddingGuid", "ReferenceNumber", "Template", "documentType" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), "34", "Sablon dokumenta", 1 });

            migrationBuilder.InsertData(
                table: "PublicBiddingLots",
                columns: new[] { "Guid", "LotGuid", "LotNumber", "PublicBiddingGuid" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), 5, new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb") });

            migrationBuilder.InsertData(
                table: "Representatives",
                columns: new[] { "Guid", "AddressGuid", "FirstName", "IdentificationNumber", "LastName", "NumberOfBoard", "PublicBiddingGuid" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), "Mladen", "0802000180857", "Krsmanovic", 1, new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb") });

            migrationBuilder.InsertData(
                table: "BiddingOffers",
                columns: new[] { "Guid", "BuyerGuid", "Date", "Offer", "PublicBiddingGuid", "RepresentativeGuid" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000f, new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb") });

            migrationBuilder.InsertData(
                table: "BuyerApplications",
                columns: new[] { "Guid", "RepresentativeGuid", "Amount" },
                values: new object[] { new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"), 60000 });

            migrationBuilder.CreateIndex(
                name: "IX_BiddingOffers_PublicBiddingGuid",
                table: "BiddingOffers",
                column: "PublicBiddingGuid");

            migrationBuilder.CreateIndex(
                name: "IX_BiddingOffers_RepresentativeGuid",
                table: "BiddingOffers",
                column: "RepresentativeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerApplications_RepresentativeGuid",
                table: "BuyerApplications",
                column: "RepresentativeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PublicBiddingGuid",
                table: "Documents",
                column: "PublicBiddingGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ReferenceNumber",
                table: "Documents",
                column: "ReferenceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PublicBiddingLots_PublicBiddingGuid",
                table: "PublicBiddingLots",
                column: "PublicBiddingGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PublicBiddings_AddresGuid",
                table: "PublicBiddings",
                column: "AddresGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_AddressGuid",
                table: "Representatives",
                column: "AddressGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_IdentificationNumber",
                table: "Representatives",
                column: "IdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Representatives_PublicBiddingGuid",
                table: "Representatives",
                column: "PublicBiddingGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiddingOffers");

            migrationBuilder.DropTable(
                name: "BuyerApplications");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "PublicBiddingLots");

            migrationBuilder.DropTable(
                name: "Representatives");

            migrationBuilder.DropTable(
                name: "PublicBiddings");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
