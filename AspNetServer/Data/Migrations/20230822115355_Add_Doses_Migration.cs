using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Doses_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dose = table.Column<double>(type: "REAL", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "17:00");

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "17:01");

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "17:02");

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "17:03");

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "17:04");

            migrationBuilder.UpdateData(
                table: "Catheters",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: "17:05");

            migrationBuilder.InsertData(
                table: "Doses",
                columns: new[] { "Id", "Dose", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1.1000000000000001, "05:29", "00:00" },
                    { 2, 1.6000000000000001, "06:59", "05:30" },
                    { 3, 1.7, "11:29", "07:00" },
                    { 4, 1.3, "21:59", "11:30" },
                    { 5, 1.3999999999999999, "23:59", "22:00" }
                });

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "17:00");

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "17:01");

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "17:02");

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "17:03");

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "17:04");

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: "17:05");

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "17:00");

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "17:01");

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "17:02");

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "17:03");

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "17:04");

            migrationBuilder.UpdateData(
                table: "Insulin",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: "17:05");

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "17:00");

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "17:01");

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: "17:02");

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: "17:03");

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: "17:04");

            migrationBuilder.UpdateData(
                table: "Sugars",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: "17:05");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doses");

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

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2023, 8, 12, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2023, 8, 11, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2023, 8, 10, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2023, 8, 9, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5,
                column: "Time",
                value: new DateTime(2023, 8, 8, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 6,
                column: "Time",
                value: new DateTime(2023, 8, 7, 22, 21, 19, 714, DateTimeKind.Local).AddTicks(5367));

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
    }
}
