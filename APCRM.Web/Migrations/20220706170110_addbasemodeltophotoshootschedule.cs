using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class addbasemodeltophotoshootschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoshootSchedule_Worksheet_WorkSheetId",
                table: "PhotoshootSchedule");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoshootSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PhotoshootSchedule",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PhotoshootSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "PhotoshootSchedule",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoshootSchedule_CreatedById",
                table: "PhotoshootSchedule",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoshootSchedule_UpdatedById",
                table: "PhotoshootSchedule",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_CreatedById",
                table: "PhotoshootSchedule",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_UpdatedById",
                table: "PhotoshootSchedule",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoshootSchedule_Worksheet_WorkSheetId",
                table: "PhotoshootSchedule",
                column: "WorkSheetId",
                principalTable: "Worksheet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_CreatedById",
                table: "PhotoshootSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_UpdatedById",
                table: "PhotoshootSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoshootSchedule_Worksheet_WorkSheetId",
                table: "PhotoshootSchedule");

            migrationBuilder.DropIndex(
                name: "IX_PhotoshootSchedule_CreatedById",
                table: "PhotoshootSchedule");

            migrationBuilder.DropIndex(
                name: "IX_PhotoshootSchedule_UpdatedById",
                table: "PhotoshootSchedule");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PhotoshootSchedule");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PhotoshootSchedule");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PhotoshootSchedule");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "PhotoshootSchedule");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoshootSchedule_Worksheet_WorkSheetId",
                table: "PhotoshootSchedule",
                column: "WorkSheetId",
                principalTable: "Worksheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
