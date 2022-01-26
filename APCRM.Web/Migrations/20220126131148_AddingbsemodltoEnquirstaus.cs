using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class AddingbsemodltoEnquirstaus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EnquiryStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "EnquiryStatus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EnquiryStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "EnquiryStatus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryStatus_CreatedById",
                table: "EnquiryStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryStatus_UpdatedById",
                table: "EnquiryStatus",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryStatus_AspNetUsers_CreatedById",
                table: "EnquiryStatus",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryStatus_AspNetUsers_UpdatedById",
                table: "EnquiryStatus",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryStatus_AspNetUsers_CreatedById",
                table: "EnquiryStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_EnquiryStatus_AspNetUsers_UpdatedById",
                table: "EnquiryStatus");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryStatus_CreatedById",
                table: "EnquiryStatus");

            migrationBuilder.DropIndex(
                name: "IX_EnquiryStatus_UpdatedById",
                table: "EnquiryStatus");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EnquiryStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "EnquiryStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EnquiryStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "EnquiryStatus");
        }
    }
}
