using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class basic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hospital",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Hospital",
                table: "AspNetUsers");
        }
    }
}
