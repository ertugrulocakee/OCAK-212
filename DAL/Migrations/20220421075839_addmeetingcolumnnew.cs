using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addmeetingcolumnnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Patient",
                table: "Meetings",
                newName: "PatientUserName");

            migrationBuilder.RenameColumn(
                name: "Doctor",
                table: "Meetings",
                newName: "PatientName");

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoktorUserName",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "DoktorUserName",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "PatientUserName",
                table: "Meetings",
                newName: "Patient");

            migrationBuilder.RenameColumn(
                name: "PatientName",
                table: "Meetings",
                newName: "Doctor");
        }
    }
}
