using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class addWorksheetPayment_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worksheet_WorkStatus_WorkFlowStatusId",
                table: "Worksheet");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WorkStatus",
                newName: "WorkStatusId");

            migrationBuilder.CreateTable(
                name: "WorksheetPaymentLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkSheetId = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetPaymentLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorksheetPaymentLog_Worksheet_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "Worksheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksheetProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkSheetId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    productquantity = table.Column<int>(type: "int", nullable: false),
                    DeliverableId = table.Column<int>(type: "int", nullable: false),
                    deliverablequantity = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorksheetProduct_Deliverables_DeliverableId",
                        column: x => x.DeliverableId,
                        principalTable: "Deliverables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetProduct_Worksheet_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "Worksheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetPaymentLog_WorkSheetId",
                table: "WorksheetPaymentLog",
                column: "WorkSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetProduct_DeliverableId",
                table: "WorksheetProduct",
                column: "DeliverableId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetProduct_ProductId",
                table: "WorksheetProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetProduct_WorkSheetId",
                table: "WorksheetProduct",
                column: "WorkSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheet_WorkStatus_WorkFlowStatusId",
                table: "Worksheet",
                column: "WorkFlowStatusId",
                principalTable: "WorkStatus",
                principalColumn: "WorkStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worksheet_WorkStatus_WorkFlowStatusId",
                table: "Worksheet");

            migrationBuilder.DropTable(
                name: "WorksheetPaymentLog");

            migrationBuilder.DropTable(
                name: "WorksheetProduct");

            migrationBuilder.RenameColumn(
                name: "WorkStatusId",
                table: "WorkStatus",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheet_WorkStatus_WorkFlowStatusId",
                table: "Worksheet",
                column: "WorkFlowStatusId",
                principalTable: "WorkStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
