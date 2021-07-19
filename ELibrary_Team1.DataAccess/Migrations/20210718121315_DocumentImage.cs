using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary_Team1.DataAccess.Migrations
{
    public partial class DocumentImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c27e2643-2c89-4c63-8f3e-d6bf62b62928", "447c9ad9-c70d-40b6-94d7-16b5c64cd792" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c037efbb-1e12-4469-8467-5e5087e2b969", "0888bc6b-5964-496e-9d46-312f25b76464" });
        }
    }
}
