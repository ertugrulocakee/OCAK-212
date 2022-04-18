using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class testingothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "appUserId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "appUserId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "appUserId",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_appUserId",
                table: "Patients",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_appUserId",
                table: "Doctors",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_appUserId",
                table: "Admins",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_appUserId",
                table: "Admins",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_appUserId",
                table: "Doctors",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_appUserId",
                table: "Patients",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_appUserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_appUserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_appUserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_appUserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_appUserId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Admins_appUserId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "appUserId",
                table: "Admins");
        }
    }
}
