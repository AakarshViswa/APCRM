using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class addingBaseModeltoEnquiry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "enquiry",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "enquiry",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "enquiry",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "enquiry",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_enquiry_CreatedById",
                table: "enquiry",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_enquiry_UpdatedById",
                table: "enquiry",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_enquiry_AspNetUsers_CreatedById",
                table: "enquiry",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_enquiry_AspNetUsers_UpdatedById",
                table: "enquiry",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enquiry_AspNetUsers_CreatedById",
                table: "enquiry");

            migrationBuilder.DropForeignKey(
                name: "FK_enquiry_AspNetUsers_UpdatedById",
                table: "enquiry");

            migrationBuilder.DropIndex(
                name: "IX_enquiry_CreatedById",
                table: "enquiry");

            migrationBuilder.DropIndex(
                name: "IX_enquiry_UpdatedById",
                table: "enquiry");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "enquiry");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "enquiry");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "enquiry");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "enquiry");
        }
    }
}
