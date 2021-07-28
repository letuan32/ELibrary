using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary_Team1.DataAccess.Migrations
{
    public partial class DropIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapters_Number",
                table: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_Title",
                table: "Chapters");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Chapters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Chapters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_Number",
                table: "Chapters",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_Title",
                table: "Chapters",
                column: "Title",
                unique: true);
        }
    }
}
