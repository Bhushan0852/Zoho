using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zoho.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data_for_billingmethod_table : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingMethods");
        }
    }
}
