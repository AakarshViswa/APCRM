using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class AddQuantitytoDockets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductDockets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "DeliverableDockets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductDockets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "DeliverableDockets");
        }
    }
}
