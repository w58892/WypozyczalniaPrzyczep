using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Caravans.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caravanmodels",
                columns: table => new
                {
                    modelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<int>(type: "int", nullable: false),
                    lengthInside = table.Column<int>(type: "int", nullable: false),
                    width = table.Column<int>(type: "int", nullable: false),
                    widthInside = table.Column<int>(type: "int", nullable: false),
                    people = table.Column<int>(type: "int", nullable: false),
                    water = table.Column<int>(type: "int", nullable: false),
                    hotWater = table.Column<bool>(type: "bit", nullable: false),
                    shower = table.Column<bool>(type: "bit", nullable: false),
                    fridge = table.Column<bool>(type: "bit", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caravanmodels_modelID", x => x.modelID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_userID", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "caravans",
                columns: table => new
                {
                    caravanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    numberPlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    modelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caravans_caravanID", x => x.caravanID);
                    table.ForeignKey(
                        name: "FK_caravans_caravanmodels",
                        column: x => x.modelID,
                        principalTable: "caravanmodels",
                        principalColumn: "modelID");
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    reservationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reservationDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    reservationBegin = table.Column<DateTime>(type: "date", nullable: false),
                    reservationEnd = table.Column<DateTime>(type: "date", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caravanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations_reservationID", x => x.reservationID);
                    table.ForeignKey(
                        name: "FK_reservations_caravans",
                        column: x => x.caravanID,
                        principalTable: "caravans",
                        principalColumn: "caravanID");
                    table.ForeignKey(
                        name: "FK_reservations_users",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID");
                });

            migrationBuilder.InsertData(
                table: "caravanmodels",
                columns: new[] { "modelID", "fridge", "hotWater", "length", "lengthInside", "model", "people", "picture", "price", "producer", "shower", "water", "weight", "width", "widthInside" },
                values: new object[,]
                {
                    { new Guid("21146366-09ad-420b-b6fb-6dc3b4d22ec2"), true, true, 4930, 4200, "PREMIO LIFE 420 TS", 3, "premio-life-420-ts.jpg", 100.00m, "BUERSNTER ", false, 12, 1100, 2120, 2050 },
                    { new Guid("299da786-b3bb-488c-b628-1698a1b40210"), true, true, 7850, 5680, "Sudwind 580 QS Silver", 5, "KNAUS-Sudwind-580-QS-Silver.jpg", 240.00m, "KNAUS", true, 25, 1260, 2500, 2340 },
                    { new Guid("5cc10dec-3f4d-451b-82fe-28a59384d3ed"), true, true, 7154, 6840, "Prestige 650 UMFe", 5, "Hobby-Prestige-650-UMFe.jpg", 250.00m, "Hobby", true, 50, 1662, 2500, 2367 },
                    { new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"), true, true, 6888, 5696, "DeLuxe 490 KMF", 5, "Hobby-DeLuxe-490-KMF.jpg", 200.00m, "Hobby", true, 25, 1252, 2300, 2172 },
                    { new Guid("a9ff9dd4-73f4-4c4d-9479-5dc186b012de"), true, true, 2633, 1950, "DeLuxe 400 SFE", 3, "Hobby-DeLuxe-400-SFE.jpg", 120.00m, "Hobby", false, 25, 1300, 2300, 2172 },
                    { new Guid("bf211dfd-c764-4b8b-afc8-97c252c56337"), true, true, 5870, 5250, "PREMIO 495 TK", 5, "PREMIO-495-TK.jpg", 250.00m, "BUERSNTER", true, 44, 1160, 2320, 2150 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userID", "email", "firstName", "lastName", "password" },
                values: new object[] { new Guid("dcd6f633-d9a3-48d7-9a2d-08db5da24aa6"), "test@test.pl", "Damian", "Oliwa", "$2a$11$12GeW/LeEDmL0BERCSsv/efXn5I8HGQ2gVdX9GUDnHWM6eCErsU2a" });

            migrationBuilder.InsertData(
                table: "caravans",
                columns: new[] { "caravanID", "modelID", "numberPlate" },
                values: new object[,]
                {
                    { new Guid("03a77cef-431a-4cd9-921e-5b4d5c473830"), new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"), "RZH4ND6" },
                    { new Guid("0ab40796-ebc0-4279-83de-30e5f3ed1049"), new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"), "RZJF35H" },
                    { new Guid("114c99b9-89a2-44d9-a6f6-eef2598dce2e"), new Guid("bf211dfd-c764-4b8b-afc8-97c252c56337"), "RZ5F2D3" },
                    { new Guid("323e9591-2f2d-4005-8fea-ba56bf7977b1"), new Guid("5cc10dec-3f4d-451b-82fe-28a59384d3ed"), "RZH3MD7" },
                    { new Guid("3279b0a5-d782-4c45-a27a-534daf9f2ed8"), new Guid("21146366-09ad-420b-b6fb-6dc3b4d22ec2"), "RZD2F5S" },
                    { new Guid("78004928-164c-4679-a416-a9508825abd9"), new Guid("299da786-b3bb-488c-b628-1698a1b40210"), "RZF2G15" },
                    { new Guid("8b1ee81b-a5cb-4b08-9db4-69d8914c26e3"), new Guid("a9ff9dd4-73f4-4c4d-9479-5dc186b012de"), "RZ47336" },
                    { new Guid("99f05bfd-194c-43b1-8458-fe7d63c32f40"), new Guid("21146366-09ad-420b-b6fb-6dc3b4d22ec2"), "RZ4BR5G" },
                    { new Guid("cc8323ce-88a6-4bca-bf85-f5442f6202bb"), new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"), "RZG3S6F" },
                    { new Guid("eb6e972e-fa5b-4627-bcc7-b676a60bd076"), new Guid("a2e32450-f315-4541-9ad6-2f9cbf5ad1e9"), "RZ8429D" },
                    { new Guid("ebdbc5ca-2fd4-4e4e-9213-a8ac3ebb42d8"), new Guid("5cc10dec-3f4d-451b-82fe-28a59384d3ed"), "RZ3BC54" },
                    { new Guid("ed844936-bab0-412e-83ac-c12f62e4a271"), new Guid("a9ff9dd4-73f4-4c4d-9479-5dc186b012de"), "RZAF542" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_caravans_modelID",
                table: "caravans",
                column: "modelID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_caravanID",
                table: "reservations",
                column: "caravanID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_userID",
                table: "reservations",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "caravans");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "caravanmodels");
        }
    }
}
