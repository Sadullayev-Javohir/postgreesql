﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfMigrationDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");
        }
    }
}
