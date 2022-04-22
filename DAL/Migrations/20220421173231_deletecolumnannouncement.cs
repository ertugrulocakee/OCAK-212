using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class deletecolumnannouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Announcements");

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementTopic",
                table: "Announcements",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementContent",
                table: "Announcements",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementTopic",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "AnnouncementContent",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Announcements",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
