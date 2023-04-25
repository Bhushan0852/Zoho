using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoho.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data_for_currency_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
