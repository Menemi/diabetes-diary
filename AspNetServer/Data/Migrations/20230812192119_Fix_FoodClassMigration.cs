using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix_FoodClassMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "BreadUnits", "Dose", "FoodName", "InsulinPinned", "Time" },
                values: new object[,]
                {
                    { 1, 3.0, 1.3, "bread, coffee", 3.9000000000000004, new DateTime(2023, 8, 12, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5341) },
                    { 2, 4.0, 1.3, "bread, coffee", 5.2000000000000002, new DateTime(2023, 8, 11, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5348) },
                    { 3, 5.0, 1.3, "bread, coffee", 6.5, new DateTime(2023, 8, 10, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5353) },
                    { 4, 6.0, 1.3, "bread, coffee", 7.8000000000000007, new DateTime(2023, 8, 9, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5358) },
                    { 5, 7.0, 1.3, "bread, coffee", 9.0999999999999996, new DateTime(2023, 8, 8, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5362) },
                    { 6, 8.0, 1.3, "bread, coffee", 10.4, new DateTime(2023, 8, 7, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5367) }
                });

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5366));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1623));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1633));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1631));
        }
    }
}
