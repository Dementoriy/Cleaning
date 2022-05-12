using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningDLL.Migrations
{
    public partial class updateService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Service",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitsID",
                table: "Service",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ReferenceUnitsOfMeasurement",
                columns: new[] { "ID", "Description", "Unit" },
                values: new object[,]
                {
                    { 1, "Измеряется в метрах квадратных", "м2" },
                    { 2, "Измеряется в штуках", "шт" },
                    { 3, "Измеряется в упаковках", "упаковка" },
                    { 4, "Измеряется в литрах", "л" },
                    { 5, "Измеряется в килограммах", "кг" },
                    { 6, "Измеряется в граммах", "г" }
                });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "ID", "Type", "Сoefficient" },
                values: new object[,]
                {
                    { 1, "Квартира", 1.2m },
                    { 2, "Дом", 1.3m },
                    { 3, "Офис", 1m },
                    { 4, "Другое", 1.5m }
                });

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "ServiceName" },
                values: new object[] { "Комплексная уборка помещений нужна, чтобы более тщательно убрать квартиру, в которой периодически убираются. Цена за 1м2.", "Комплексная уборка" });

            migrationBuilder.CreateIndex(
                name: "IX_Service_UnitsID",
                table: "Service",
                column: "UnitsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ReferenceUnitsOfMeasurement_UnitsID",
                table: "Service",
                column: "UnitsID",
                principalTable: "ReferenceUnitsOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ReferenceUnitsOfMeasurement_UnitsID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_UnitsID",
                table: "Service");

            migrationBuilder.DeleteData(
                table: "ReferenceUnitsOfMeasurement",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReferenceUnitsOfMeasurement",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReferenceUnitsOfMeasurement",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReferenceUnitsOfMeasurement",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReferenceUnitsOfMeasurement",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReferenceUnitsOfMeasurement",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "UnitsID",
                table: "Service");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Description", "ServiceName" },
                values: new object[] { "Уборка офисных помещений. Цена за 1м2.", "Уборка офисов" });
        }
    }
}
