using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class colorcodeadditiontostatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "WorkStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "WorkStatus");
        }
    }
}
