using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class changesinphotoshoot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_AssignedTo",
                table: "PhotoshootSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "PhotoshootSchedule",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_AssignedTo",
                table: "PhotoshootSchedule",
                column: "AssignedTo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_AssignedTo",
                table: "PhotoshootSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedTo",
                table: "PhotoshootSchedule",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoshootSchedule_AspNetUsers_AssignedTo",
                table: "PhotoshootSchedule",
                column: "AssignedTo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
