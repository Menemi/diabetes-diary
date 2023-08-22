using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetServer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSugarMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.CreateTable(
                name: "Sugars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sugar = table.Column<double>(type: "REAL", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InsulinIncreased = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sugars",
                columns: new[] { "Id", "InsulinIncreased", "Sugar", "Time" },
                values: new object[,]
                {
                    { 1, 0.0, 5.0999999999999996, new DateTime(2023, 8, 10, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8539) },
                    { 2, 0.0, 5.2000000000000002, new DateTime(2023, 8, 9, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8545) },
                    { 3, 0.0, 5.2999999999999998, new DateTime(2023, 8, 8, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8547) },
                    { 4, 0.0, 5.4000000000000004, new DateTime(2023, 8, 7, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8549) },
                    { 5, 0.0, 5.5, new DateTime(2023, 8, 6, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8551) },
                    { 6, 0.0, 5.5999999999999996, new DateTime(2023, 8, 5, 14, 46, 39, 237, DateTimeKind.Local).AddTicks(8552) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sugars");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100000, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "This is post 1 with some content", "Post 1" },
                    { 2, "This is post 2 with some content", "Post 2" },
                    { 3, "This is post 3 with some content", "Post 3" },
                    { 4, "This is post 4 with some content", "Post 4" },
                    { 5, "This is post 5 with some content", "Post 5" },
                    { 6, "This is post 6 with some content", "Post 6" }
                });
        }
    }
}
