using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Scaffolding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__B611CB9DC89E9510", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locID = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    province = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__793196EBDFE2B813", x => x.locID);
                });

            migrationBuilder.CreateTable(
                name: "PropertySet",
                columns: table => new
                {
                    propID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Property__DEA33C34CBD59668", x => x.propID);
                });

            migrationBuilder.CreateTable(
                name: "temptable",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    bookingID = table.Column<int>(type: "int", nullable: false),
                    bookingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    arrivalDate = table.Column<DateOnly>(type: "date", nullable: true),
                    departureDate = table.Column<DateOnly>(type: "date", nullable: true),
                    numberOfGuests = table.Column<int>(type: "int", nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    accID = table.Column<int>(type: "int", nullable: false),
                    locID = table.Column<int>(type: "int", nullable: false),
                    accommodationName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    imageURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    province = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    wishID = table.Column<int>(type: "int", nullable: false),
                    propID = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    propertySetName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    accID = table.Column<int>(type: "int", nullable: false),
                    locID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    imageURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accommod__A471AFFAE2BD3FB1", x => x.accID);
                    table.ForeignKey(
                        name: "FK__Accommoda__locID__5CD6CB2B",
                        column: x => x.locID,
                        principalTable: "Location",
                        principalColumn: "locID");
                });

            migrationBuilder.CreateTable(
                name: "Wishes",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false),
                    wishID = table.Column<int>(type: "int", nullable: false),
                    propID = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Wishes__3B3FBE5ACD8A4F9C", x => new { x.customerID, x.wishID });
                    table.ForeignKey(
                        name: "FK__Wishes__customer__6754599E",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID");
                    table.ForeignKey(
                        name: "FK__Wishes__propID__68487DD7",
                        column: x => x.propID,
                        principalTable: "PropertySet",
                        principalColumn: "propID");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingID = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    accID = table.Column<int>(type: "int", nullable: false),
                    bookingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    arrivalDate = table.Column<DateOnly>(type: "date", nullable: true),
                    departureDate = table.Column<DateOnly>(type: "date", nullable: true),
                    numberOfGuests = table.Column<int>(type: "int", nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bookings__C6D03BED2845214B", x => x.bookingID);
                    table.ForeignKey(
                        name: "FK__Bookings__accID__60A75C0F",
                        column: x => x.accID,
                        principalTable: "Accommodations",
                        principalColumn: "accID");
                    table.ForeignKey(
                        name: "FK__Bookings__custom__5FB337D6",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID");
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    accID = table.Column<int>(type: "int", nullable: false),
                    propID = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Properti__F99B9C39D9BD3A58", x => new { x.accID, x.propID });
                    table.ForeignKey(
                        name: "FK__Propertie__accID__6383C8BA",
                        column: x => x.accID,
                        principalTable: "Accommodations",
                        principalColumn: "accID");
                    table.ForeignKey(
                        name: "FK__Propertie__propI__6477ECF3",
                        column: x => x.propID,
                        principalTable: "PropertySet",
                        principalColumn: "propID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_locID",
                table: "Accommodations",
                column: "locID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_accID",
                table: "Bookings",
                column: "accID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_customerID",
                table: "Bookings",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_propID",
                table: "Properties",
                column: "propID");

            migrationBuilder.CreateIndex(
                name: "IX_Wishes_propID",
                table: "Wishes",
                column: "propID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "temptable");

            migrationBuilder.DropTable(
                name: "Wishes");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PropertySet");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
