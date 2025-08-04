using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyEfCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "EnrolledDate", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali Valiyev" },
                    { 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shahnoza Karimova" }
                });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "Id", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Matematika" },
                    { 2, 2, "Fizika" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "course",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
