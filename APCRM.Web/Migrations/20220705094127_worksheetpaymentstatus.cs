using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class worksheetpaymentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorksheetPaymentStatus",
                columns: table => new
                {
                    WorksheetPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkSheetId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetPaymentStatus", x => x.WorksheetPaymentId);
                    table.ForeignKey(
                        name: "FK_WorksheetPaymentStatus_Worksheet_WorkSheetId",
                        column: x => x.WorkSheetId,
                        principalTable: "Worksheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetPaymentStatus_WorkStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "WorkStatus",
                        principalColumn: "WorkStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetPaymentStatus_PaymentStatusId",
                table: "WorksheetPaymentStatus",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetPaymentStatus_WorkSheetId",
                table: "WorksheetPaymentStatus",
                column: "WorkSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorksheetPaymentStatus");
        }
    }
}
