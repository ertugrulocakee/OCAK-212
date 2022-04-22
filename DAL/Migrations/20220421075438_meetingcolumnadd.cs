using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class meetingcolumnadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "Patient",
                table: "Meetings");
        }
    }
}
