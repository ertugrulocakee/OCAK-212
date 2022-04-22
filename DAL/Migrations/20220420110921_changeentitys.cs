using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeentitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Doctors_DoctorID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Patients_PatientID",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Secretaries");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_DoctorID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_PatientID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Meetings");

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

            migrationBuilder.AddColumn<string>(
                name: "branch",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hospital",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "userType",
                table: "AspNetUsers",
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

            migrationBuilder.DropColumn(
                name: "branch",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "hospital",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userType",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Hospitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Secretaries",
                columns: table => new
                {
                    SecretaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    HospitalID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretaries", x => x.SecretaryID);
                    table.ForeignKey(
                        name: "FK_Secretaries_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Secretaries_Hospitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_DoctorID",
                table: "Meetings",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_PatientID",
                table: "Meetings",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppUserId",
                table: "Doctors",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_BranchID",
                table: "Doctors",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalID",
                table: "Doctors",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppUserId",
                table: "Patients",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretaries_AppUserId",
                table: "Secretaries",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretaries_HospitalID",
                table: "Secretaries",
                column: "HospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Doctors_DoctorID",
                table: "Meetings",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Patients_PatientID",
                table: "Meetings",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
