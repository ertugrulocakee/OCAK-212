using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Secretaries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Admins",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Secretaries",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admins",
                newName: "UserID");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
