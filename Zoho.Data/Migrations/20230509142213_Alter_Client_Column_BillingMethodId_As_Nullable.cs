using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoho.Data.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Client_Column_BillingMethodId_As_Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_BillingMethods_BillingMethodId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "BillingMethodId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_BillingMethods_BillingMethodId",
                table: "Clients",
                column: "BillingMethodId",
                principalTable: "BillingMethods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_BillingMethods_BillingMethodId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "BillingMethodId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_BillingMethods_BillingMethodId",
                table: "Clients",
                column: "BillingMethodId",
                principalTable: "BillingMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
