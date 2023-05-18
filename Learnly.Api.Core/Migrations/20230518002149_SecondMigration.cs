using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learnly.Api.Core.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbcencesLimit",
                table: "Abcenses");

            migrationBuilder.AddColumn<int>(
                name: "AbcencesLimit",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbcencesLimit",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "AbcencesLimit",
                table: "Abcenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
