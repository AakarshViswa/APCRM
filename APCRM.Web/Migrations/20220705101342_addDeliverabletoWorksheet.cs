using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class addDeliverabletoWorksheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorksheetProduct_Deliverables_DeliverableId",
                table: "WorksheetProduct");

            migrationBuilder.DropIndex(
                name: "IX_WorksheetProduct_DeliverableId",
                table: "WorksheetProduct");

            migrationBuilder.DropColumn(
                name: "DeliverableId",
                table: "WorksheetProduct");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "WorksheetProduct");

            migrationBuilder.RenameColumn(
                name: "deliverablequantity",
                table: "WorksheetProduct",
                newName: "TotalProductCost");

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "Worksheet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorksheetDeliverable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkSheetId = table.Column<int>(type: "int", nullable: false),
                    DeliverableId = table.Column<int>(type: "int", nullable: false),
                    deliverablequantity = table.Column<int>(type: "int", nullable: false),
                    TotalDeliverableCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetDeliverable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorksheetDeliverable_Deliverables_DeliverableId",
                        column: x => x.DeliverableId,
                        principalTable: "Deliverables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetDeliverable_Worksheet_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "Worksheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetDeliverable_DeliverableId",
                table: "WorksheetDeliverable",
                column: "DeliverableId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetDeliverable_WorkSheetId",
                table: "WorksheetDeliverable",
                column: "WorkSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorksheetDeliverable");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Worksheet");

            migrationBuilder.RenameColumn(
                name: "TotalProductCost",
                table: "WorksheetProduct",
                newName: "deliverablequantity");

            migrationBuilder.AddColumn<int>(
                name: "DeliverableId",
                table: "WorksheetProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "WorksheetProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetProduct_DeliverableId",
                table: "WorksheetProduct",
                column: "DeliverableId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorksheetProduct_Deliverables_DeliverableId",
                table: "WorksheetProduct",
                column: "DeliverableId",
                principalTable: "Deliverables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
