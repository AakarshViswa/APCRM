using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APCRM.Web.Migrations
{
    public partial class AddingBasemodeltoPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductDockets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ProductDockets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductDockets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ProductDockets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Packages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Deliverables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Deliverables",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Deliverables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Deliverables",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "DeliverableDockets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DeliverableDockets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "DeliverableDockets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "DeliverableDockets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedById",
                table: "Products",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDockets_CreatedById",
                table: "ProductDockets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDockets_UpdatedById",
                table: "ProductDockets",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CreatedById",
                table: "Packages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_UpdatedById",
                table: "Packages",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_CreatedById",
                table: "Deliverables",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_UpdatedById",
                table: "Deliverables",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableDockets_CreatedById",
                table: "DeliverableDockets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverableDockets_UpdatedById",
                table: "DeliverableDockets",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliverableDockets_AspNetUsers_CreatedById",
                table: "DeliverableDockets",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliverableDockets_AspNetUsers_UpdatedById",
                table: "DeliverableDockets",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliverables_AspNetUsers_CreatedById",
                table: "Deliverables",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliverables_AspNetUsers_UpdatedById",
                table: "Deliverables",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_CreatedById",
                table: "Packages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_UpdatedById",
                table: "Packages",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDockets_AspNetUsers_CreatedById",
                table: "ProductDockets",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDockets_AspNetUsers_UpdatedById",
                table: "ProductDockets",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UpdatedById",
                table: "Products",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliverableDockets_AspNetUsers_CreatedById",
                table: "DeliverableDockets");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliverableDockets_AspNetUsers_UpdatedById",
                table: "DeliverableDockets");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliverables_AspNetUsers_CreatedById",
                table: "Deliverables");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliverables_AspNetUsers_UpdatedById",
                table: "Deliverables");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_CreatedById",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_UpdatedById",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDockets_AspNetUsers_CreatedById",
                table: "ProductDockets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDockets_AspNetUsers_UpdatedById",
                table: "ProductDockets");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UpdatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UpdatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductDockets_CreatedById",
                table: "ProductDockets");

            migrationBuilder.DropIndex(
                name: "IX_ProductDockets_UpdatedById",
                table: "ProductDockets");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CreatedById",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_UpdatedById",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Deliverables_CreatedById",
                table: "Deliverables");

            migrationBuilder.DropIndex(
                name: "IX_Deliverables_UpdatedById",
                table: "Deliverables");

            migrationBuilder.DropIndex(
                name: "IX_DeliverableDockets_CreatedById",
                table: "DeliverableDockets");

            migrationBuilder.DropIndex(
                name: "IX_DeliverableDockets_UpdatedById",
                table: "DeliverableDockets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProductDockets");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductDockets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProductDockets");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ProductDockets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Deliverables");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Deliverables");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Deliverables");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Deliverables");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DeliverableDockets");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DeliverableDockets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DeliverableDockets");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "DeliverableDockets");
        }
    }
}
