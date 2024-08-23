using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMajorFacility",
                table: "Staff_Major");

            migrationBuilder.DropColumn(
                name: "IdDepartmentFacility",
                table: "Major_Facility");

            migrationBuilder.DropColumn(
                name: "IdDepartment",
                table: "Department_Facility");

            migrationBuilder.DropColumn(
                name: "IdFacility",
                table: "Department_Facility");

            migrationBuilder.DropColumn(
                name: "IdHeadOfDepartment",
                table: "Department_Facility");

            migrationBuilder.RenameColumn(
                name: "IdStaff",
                table: "Staff_Major",
                newName: "MajorFacilityId");

            migrationBuilder.RenameColumn(
                name: "IdMajor",
                table: "Major_Facility",
                newName: "DepartmentFacilityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MajorFacilityId",
                table: "Staff_Major",
                newName: "IdStaff");

            migrationBuilder.RenameColumn(
                name: "DepartmentFacilityId",
                table: "Major_Facility",
                newName: "IdMajor");

            migrationBuilder.AddColumn<Guid>(
                name: "IdMajorFacility",
                table: "Staff_Major",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdDepartmentFacility",
                table: "Major_Facility",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdDepartment",
                table: "Department_Facility",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdFacility",
                table: "Department_Facility",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdHeadOfDepartment",
                table: "Department_Facility",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
