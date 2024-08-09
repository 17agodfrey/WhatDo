using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DateFinder.Storage.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIndoorOutdoorBothtoAny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 5,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 9,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 11,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 26,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 29,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 34,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 39,
                column: "IndoorOutdoor",
                value: "Any");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 43,
                column: "IndoorOutdoor",
                value: "Any");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 5,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 9,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 11,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 26,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 29,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 34,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 39,
                column: "IndoorOutdoor",
                value: "Both");

            migrationBuilder.UpdateData(
                table: "Dates",
                keyColumn: "Id",
                keyValue: 43,
                column: "IndoorOutdoor",
                value: "Both");
        }
    }
}
