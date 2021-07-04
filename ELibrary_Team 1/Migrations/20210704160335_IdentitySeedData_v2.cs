using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary_Team_1.Migrations
{
    public partial class IdentitySeedData_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessRequests_Users_UserId",
                table: "AccessRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateRequest_Users_UserId",
                table: "UpdateRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_Users_UserId",
                table: "UserVotes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "53abf2bc-df4f-4f7e-9ac2-5c8719111f5c", "3e25da6f-60b8-4298-b091-4fb9371c8243" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccessRequests_Users_UserId",
                table: "AccessRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateRequest_Users_UserId",
                table: "UpdateRequest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_Users_UserId",
                table: "UserVotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessRequests_Users_UserId",
                table: "AccessRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateRequest_Users_UserId",
                table: "UpdateRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_Users_UserId",
                table: "UserVotes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cf929a6c-687c-4316-8d99-b3a58565a5e0", "0bb6ff0c-118a-4b1c-8d52-4752b4c9a97e" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccessRequests_Users_UserId",
                table: "AccessRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateRequest_Users_UserId",
                table: "UpdateRequest",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_Users_UserId",
                table: "UserVotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
