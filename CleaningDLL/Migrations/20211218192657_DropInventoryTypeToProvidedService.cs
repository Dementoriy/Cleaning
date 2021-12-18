using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningDLL.Migrations
{
    public partial class DropInventoryTypeToProvidedService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvidedService_Inventory_InventoryID",
                table: "ProvidedService");

            migrationBuilder.DropIndex(
                name: "IX_ProvidedService_InventoryID",
                table: "ProvidedService");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "ProvidedService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "ProvidedService",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_InventoryID",
                table: "ProvidedService",
                column: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidedService_Inventory_InventoryID",
                table: "ProvidedService",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
