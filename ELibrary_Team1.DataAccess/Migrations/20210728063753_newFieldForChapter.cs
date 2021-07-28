using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary_Team1.DataAccess.Migrations
{
    public partial class newFieldForChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Number", "Title" },
                values: new object[] { "Chapter 1", "Introduction" });

            migrationBuilder.UpdateData(
                table: "Chapters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Number", "Title" },
                values: new object[] { "Chapter 1", "Table of Content" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Chapters");
        }
    }
}
