using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class testingsecret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appUserId",
                table: "Secretaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Secretaries_appUserId",
                table: "Secretaries",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Secretaries_AspNetUsers_appUserId",
                table: "Secretaries",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secretaries_AspNetUsers_appUserId",
                table: "Secretaries");

            migrationBuilder.DropIndex(
                name: "IX_Secretaries_appUserId",
                table: "Secretaries");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Secretaries");
        }
    }
}
