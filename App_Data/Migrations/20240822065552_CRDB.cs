using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data.Migrations
{
    /// <inheritdoc />
    public partial class CRDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AccountFE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountFPT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department_Facility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDepartment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHeadOfDepartment = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Facility_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_Facility_Facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Major_Facility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDepartmentFacility = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMajor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    department_FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MajorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major_Facility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Major_Facility_Department_Facility_department_FacilityId",
                        column: x => x.department_FacilityId,
                        principalTable: "Department_Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Major_Facility_Major_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Major",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMajorFacility = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    major_FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Major", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Major_Major_Facility_major_FacilityId",
                        column: x => x.major_FacilityId,
                        principalTable: "Major_Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Major_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_Facility_DepartmentId",
                table: "Department_Facility",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Facility_FacilityId",
                table: "Department_Facility",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_FacilityId",
                table: "Facility",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Major_Facility_department_FacilityId",
                table: "Major_Facility",
                column: "department_FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Major_Facility_MajorId",
                table: "Major_Facility",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AccountFE",
                table: "Staff",
                column: "AccountFE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AccountFPT",
                table: "Staff",
                column: "AccountFPT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Code",
                table: "Staff",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Major_major_FacilityId",
                table: "Staff_Major",
                column: "major_FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Major_StaffId",
                table: "Staff_Major",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff_Major");

            migrationBuilder.DropTable(
                name: "Major_Facility");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Department_Facility");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Facility");
        }
    }
}
