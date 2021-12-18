using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningDLL.Migrations
{
    public partial class DropReferenceUnitsOfMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvidedService_ReferenceUnitsOfMeasurement_ReferenceUnitsO~",
                table: "ProvidedService");

            migrationBuilder.DropIndex(
                name: "IX_ProvidedService_ReferenceUnitsOfMeasurementID",
                table: "ProvidedService");

            migrationBuilder.DropColumn(
                name: "ReferenceUnitsOfMeasurementID",
                table: "ProvidedService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceUnitsOfMeasurementID",
                table: "ProvidedService",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_ReferenceUnitsOfMeasurementID",
                table: "ProvidedService",
                column: "ReferenceUnitsOfMeasurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidedService_ReferenceUnitsOfMeasurement_ReferenceUnitsO~",
                table: "ProvidedService",
                column: "ReferenceUnitsOfMeasurementID",
                principalTable: "ReferenceUnitsOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
