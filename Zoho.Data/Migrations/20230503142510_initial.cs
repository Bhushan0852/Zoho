using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoho.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNuber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    BillingMethodId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_BillingMethods_BillingMethodId",
                        column: x => x.BillingMethodId,
                        principalTable: "BillingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillingMethods",
                columns: new[] { "Id", "CreatedBy", "CreatedTimestamp", "IsDeleted", "MethodType", "UpdatedBy", "UpdatedTimestamp" },
                values: new object[,]
                {
                    { 1, null, null, false, "Hourly Job Rate", null, null },
                    { 2, null, null, false, "Hourly User Rate", null, null },
                    { 3, null, null, false, "Hourly User Rate - Jobs", null, null },
                    { 4, null, null, false, "Hourly User Rate - Projects", null, null }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Country", "CreatedBy", "CreatedTimestamp", "IsDeleted", "UpdatedBy", "UpdatedTimestamp" },
                values: new object[,]
                {
                    { 1, "USD", "United States", null, null, false, null, null },
                    { 2, "INR", "India", null, null, false, null, null },
                    { 3, "EUR", "Germany", null, null, false, null, null },
                    { 4, "JPY", "Japan", null, null, false, null, null },
                    { 5, "AUD", "Australia", null, null, false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BillingMethodId",
                table: "Clients",
                column: "BillingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CurrencyId",
                table: "Clients",
                column: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "BillingMethods");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
