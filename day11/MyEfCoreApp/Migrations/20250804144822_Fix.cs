using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEfCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrolledDate",
                table: "students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EnrolledDate",
                table: "students",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_DATE");

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "Id",
                keyValue: 1,
                column: "EnrolledDate",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "students",
                keyColumn: "Id",
                keyValue: 2,
                column: "EnrolledDate",
                value: new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
