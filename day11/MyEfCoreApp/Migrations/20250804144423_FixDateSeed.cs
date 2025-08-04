using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEfCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class FixDateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_students_StudentId",
                table: "course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course",
                table: "course");

            migrationBuilder.RenameTable(
                name: "course",
                newName: "courses");

            migrationBuilder.RenameIndex(
                name: "IX_course_StudentId",
                table: "courses",
                newName: "IX_courses_StudentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrolledDate",
                table: "students",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_students_StudentId",
                table: "courses",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_students_StudentId",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "course");

            migrationBuilder.RenameIndex(
                name: "IX_courses_StudentId",
                table: "course",
                newName: "IX_course_StudentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrolledDate",
                table: "students",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "CURRENT_DATE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course",
                table: "course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_students_StudentId",
                table: "course",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
