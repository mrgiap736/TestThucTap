using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Facility_FacilityId",
                table: "Facility");

            migrationBuilder.DropIndex(
                name: "IX_Facility_FacilityId",
                table: "Facility");

            migrationBuilder.DropColumn(
                name: "FacilityId",
                table: "Facility");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FacilityId",
                table: "Facility",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facility_FacilityId",
                table: "Facility",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Facility_FacilityId",
                table: "Facility",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "Id");
        }
    }
}
