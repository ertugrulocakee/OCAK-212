using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class fixingid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Secretaries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Secretaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
