using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Food_Insulin_Catheter_ClassesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catheters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catheters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dose = table.Column<double>(type: "REAL", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BreadUnits = table.Column<double>(type: "REAL", nullable: false),
                    InsulinPinned = table.Column<double>(type: "REAL", nullable: false),
                    FoodName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insulin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insulin", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Catheters",
                columns: new[] { "Id", "Time" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 12, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1606) },
                    { 2, new DateTime(2023, 8, 11, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1612) },
                    { 3, new DateTime(2023, 8, 10, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1618) },
                    { 4, new DateTime(2023, 8, 9, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1623) },
                    { 5, new DateTime(2023, 8, 8, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1629) },
                    { 6, new DateTime(2023, 8, 7, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1634) }
                });

            migrationBuilder.InsertData(
                table: "Insulin",
                columns: new[] { "Id", "Time" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 12, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1604) },
                    { 2, new DateTime(2023, 8, 11, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1611) },
                    { 3, new DateTime(2023, 8, 10, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1617) },
                    { 4, new DateTime(2023, 8, 9, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1623) },
                    { 5, new DateTime(2023, 8, 8, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1628) },
                    { 6, new DateTime(2023, 8, 7, 22, 17, 42, 613, DateTimeKind.Local).AddTicks(1633) }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catheters");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Insulin");

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
    }
}
