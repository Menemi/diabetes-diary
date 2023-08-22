using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSugarMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 11, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 10, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 9, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 8, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 7, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 6, 14, 51, 44, 810, DateTimeKind.Local).AddTicks(1653));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 10, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 9, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 8, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 7, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 6, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 5, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8552));
        }
    }
}
