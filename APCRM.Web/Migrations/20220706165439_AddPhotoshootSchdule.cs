using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class AddPhotoshootSchdule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoshootSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkSheetId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoshootSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoshootSchedule_AspNetUsers_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PhotoshootSchedule_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PhotoshootSchedule_Worksheet_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "Worksheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoshootSchedule_AssignedTo",
                table: "PhotoshootSchedule",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoshootSchedule_ProductId",
                table: "PhotoshootSchedule",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoshootSchedule_WorkSheetId",
                table: "PhotoshootSchedule",
                column: "WorkSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoshootSchedule");
        }
    }
}
