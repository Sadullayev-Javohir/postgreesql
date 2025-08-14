using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seeding.Migrations
{
    /// <inheritdoc />
    public partial class SeedingMigrationsNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productss",
                table: "Productss");

            migrationBuilder.RenameTable(
                name: "Productss",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Productss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productss",
                table: "Productss",
                column: "Id");
        }
    }
}
