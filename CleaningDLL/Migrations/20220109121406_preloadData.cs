using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningDLL.Migrations
{
    public partial class preloadData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrigadeInventory_Brigade_BrigadeID",
                table: "BrigadeInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_BrigadeInventory_Inventory_InventoryID",
                table: "BrigadeInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_ReferenceUnitsOfMeasurement_UnitID",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesService_ConsumptionRate_Consumption_RateID",
                table: "ConsumablesService");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesService_Service_ServiceID",
                table: "ConsumablesService");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumptionRate_Consumable_ConsumableID",
                table: "ConsumptionRate");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumptionRate_ReferenceUnitsOfMeasurement_UnitID",
                table: "ConsumptionRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Employee_EmployeeID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_DeliveryContent_Delivery_ContentID",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Provider_ProviderID",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContent_Consumable_ConsumableID",
                table: "DeliveryContent");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContract_Employee_EmployeeID",
                table: "DeliveryContract");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContract_Provider_ProviderID",
                table: "DeliveryContract");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContract_PurchaseRequisition_Purchase_RequisitionID",
                table: "DeliveryContract");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_InventoryType_Inventory_TypeID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Address_ProviderAddressID",
                table: "Provider");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisition_Employee_EmployeeID",
                table: "PurchaseRequisition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisition_Provider_ProviderID",
                table: "PurchaseRequisition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisition_RequisitionContent_RequisitionContentID",
                table: "PurchaseRequisition");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionContent_Consumable_ConsumableID",
                table: "RequisitionContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_InventoryType_Inventory_TypeID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_Inventory_TypeID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Provider_ProviderAddressID",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Inventory_TypeID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryContract_Purchase_RequisitionID",
                table: "DeliveryContract");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_Delivery_ContentID",
                table: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_ConsumptionRate_UnitID",
                table: "ConsumptionRate");

            migrationBuilder.DropIndex(
                name: "IX_ConsumablesService_Consumption_RateID",
                table: "ConsumablesService");

            migrationBuilder.DropIndex(
                name: "IX_Consumable_UnitID",
                table: "Consumable");

            migrationBuilder.DropColumn(
                name: "Inventory_TypeID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ProviderAddressID",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "Inventory_TypeID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Purchase_RequisitionID",
                table: "DeliveryContract");

            migrationBuilder.DropColumn(
                name: "Delivery_ContentID",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "ConsumptionRate");

            migrationBuilder.DropColumn(
                name: "Consumption_RateID",
                table: "ConsumablesService");

            migrationBuilder.DropColumn(
                name: "UnitID",
                table: "Consumable");

            migrationBuilder.RenameColumn(
                name: "Service_Name",
                table: "Service",
                newName: "ServiceName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "InventoryType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Use_Time",
                table: "Inventory",
                newName: "UseTime");

            migrationBuilder.RenameColumn(
                name: "Life_Time",
                table: "Inventory",
                newName: "LifeTime");

            migrationBuilder.RenameColumn(
                name: "Inventory_Name",
                table: "Inventory",
                newName: "InventoryName");

            migrationBuilder.RenameColumn(
                name: "Date_of_Receiving",
                table: "Inventory",
                newName: "DateOfReceiving");

            migrationBuilder.RenameColumn(
                name: "Delivery_Contract_Date",
                table: "DeliveryContract",
                newName: "DeliveryContractDate");

            migrationBuilder.RenameColumn(
                name: "Delivery_Content_Amount",
                table: "DeliveryContent",
                newName: "DeliveryContentAmount");

            migrationBuilder.RenameColumn(
                name: "Delivery_Date",
                table: "Delivery",
                newName: "DeliveryDate");

            migrationBuilder.RenameColumn(
                name: "Delivery_Cost",
                table: "Delivery",
                newName: "DeliveryCost");

            migrationBuilder.RenameColumn(
                name: "Date_Of_Contract",
                table: "Contract",
                newName: "DateOfContract");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Consumable",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Current_Price",
                table: "Consumable",
                newName: "CurrentPrice");

            migrationBuilder.RenameColumn(
                name: "Consumable_Name",
                table: "Consumable",
                newName: "ConsumableName");

            migrationBuilder.RenameIndex(
                name: "IX_Consumable_Consumable_Name",
                table: "Consumable",
                newName: "IX_Consumable_ConsumableName");

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeID",
                table: "Service",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableID",
                table: "RequisitionContent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionContentID",
                table: "PurchaseRequisition",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderID",
                table: "PurchaseRequisition",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "PurchaseRequisition",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Provider",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryTypeID",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderID",
                table: "DeliveryContract",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "DeliveryContract",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseRequisitionID",
                table: "DeliveryContract",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableID",
                table: "DeliveryContent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderID",
                table: "Delivery",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryContentID",
                table: "Delivery",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Contract",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Contract",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableID",
                table: "ConsumptionRate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceUnitsOfMeasurementID",
                table: "ConsumptionRate",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceID",
                table: "ConsumablesService",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsumptionRateID",
                table: "ConsumablesService",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceUnitsOfMeasurementID",
                table: "Consumable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "BrigadeInventory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrigadeID",
                table: "BrigadeInventory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Brigade",
                columns: new[] { "ID", "Smena_Number" },
                values: new object[,]
                {
                    { 1, "Смена1" },
                    { 2, "Смена2" }
                });

            migrationBuilder.InsertData(
                table: "InventoryType",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Пылесос" },
                    { 2, "Стеклоочиститель" },
                    { 3, "Вакуумный очиститель" },
                    { 4, "Дезинфектор" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "ID", "Description", "NamePosition" },
                values: new object[,]
                {
                    { 1, "Обрабатывать заявки", "Администратор" },
                    { 2, "Главный клинер. Заведует бригадой", "Бригадир" },
                    { 3, "Совершать уборку на объекте", "Клинер" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "ID", "BrigadeID", "EmployeeTelefonNumber", "Employment_Date", "Login", "MiddleName", "Name", "PassportData", "Password", "PositionID", "Surname" },
                values: new object[,]
                {
                    { 7, 2, "+79229357609", new DateTime(2021, 12, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Константинович", "Дмитрий", "1111888888", null, 3, "Целищев" },
                    { 5, 1, "+79091324445", new DateTime(2021, 12, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), null, "Владимирович", "Роман", "1111666666", null, 3, "Суслов" },
                    { 4, 1, "+79536952565", new DateTime(2021, 12, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), null, "Игоревич", "Дмитрий", "1111555555", null, 3, "Москалев" },
                    { 3, 2, "+79123646993", new DateTime(2021, 11, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), "brigadir2", "Николаевич", "Александр", "1111444444", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "Заболотский" },
                    { 2, 1, "+79536856008", new DateTime(2021, 11, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), "brigadir1", "Анатольевич", "Иван", "1111333333", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", 2, "Бессонов" },
                    { 1, null, "+79536773183", new DateTime(2021, 11, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "admin", "Михайлович", "Дмитрий", "1111222222", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", 1, "Ведерников" },
                    { 6, 2, "+79123644673", new DateTime(2021, 12, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "Игоревич", "Максим", "1111777777", null, 3, "Орлов" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ID", "Description", "InventoryTypeID", "Price", "ServiceName", "Time" },
                values: new object[,]
                {
                    { 10, "Дезинфекция помещений, твердых поверхносте, воздуха. Цена за 1м2.", 4, 40m, "Дезинфекция", 30 },
                    { 9, "Химчистка ковров, матрасов. Цена за 1м2.", 3, 150m, "Химчистка ковров", 300 },
                    { 7, "Химчистка диванов. Мягкой мебели. Цена за 1 место.", 3, 300m, "Химчистка диванов", 3600 },
                    { 6, "Мойка стеклянных дверей балконов и лоджий. Цена за 1 дверь.", 2, 500m, "Мойка стеклянных дверей", 120 },
                    { 5, "Мойка окон. Цена за 1 створу.", 2, 250m, "Мойка окон", 60 },
                    { 4, "Уборка офисных помещений. Цена за 1м2.", 1, 50m, "Уборка офисов", 100 },
                    { 3, "Уборка на объекте после ремонта/стройки (Обильное загрязнение). Цена за 1м2.", 1, 80m, "Послестроительная уборка", 220 },
                    { 2, "Генеральная уборка. Цена за 1м2.", 1, 70m, "Генеральная уборка", 220 },
                    { 8, "Химчистка кресел. Мягкой мебели. Цена за 1 кресло.", 3, 300m, "Химчистка кресел", 3600 },
                    { 1, "Поддерживающая уборка. Объект должен быть в незапущенном состоянии. Цена за 1м2.", 1, 40m, "Экспресс уборка", 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_InventoryTypeID",
                table: "Service",
                column: "InventoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_AddressID",
                table: "Provider",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryTypeID",
                table: "Inventory",
                column: "InventoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContract_PurchaseRequisitionID",
                table: "DeliveryContract",
                column: "PurchaseRequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryContentID",
                table: "Delivery",
                column: "DeliveryContentID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionRate_ReferenceUnitsOfMeasurementID",
                table: "ConsumptionRate",
                column: "ReferenceUnitsOfMeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesService_ConsumptionRateID",
                table: "ConsumablesService",
                column: "ConsumptionRateID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_ReferenceUnitsOfMeasurementID",
                table: "Consumable",
                column: "ReferenceUnitsOfMeasurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_BrigadeInventory_Brigade_BrigadeID",
                table: "BrigadeInventory",
                column: "BrigadeID",
                principalTable: "Brigade",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrigadeInventory_Inventory_InventoryID",
                table: "BrigadeInventory",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_ReferenceUnitsOfMeasurement_ReferenceUnitsOfMeas~",
                table: "Consumable",
                column: "ReferenceUnitsOfMeasurementID",
                principalTable: "ReferenceUnitsOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesService_ConsumptionRate_ConsumptionRateID",
                table: "ConsumablesService",
                column: "ConsumptionRateID",
                principalTable: "ConsumptionRate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesService_Service_ServiceID",
                table: "ConsumablesService",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumptionRate_Consumable_ConsumableID",
                table: "ConsumptionRate",
                column: "ConsumableID",
                principalTable: "Consumable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumptionRate_ReferenceUnitsOfMeasurement_ReferenceUnitsO~",
                table: "ConsumptionRate",
                column: "ReferenceUnitsOfMeasurementID",
                principalTable: "ReferenceUnitsOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Employee_EmployeeID",
                table: "Contract",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_DeliveryContent_DeliveryContentID",
                table: "Delivery",
                column: "DeliveryContentID",
                principalTable: "DeliveryContent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Provider_ProviderID",
                table: "Delivery",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContent_Consumable_ConsumableID",
                table: "DeliveryContent",
                column: "ConsumableID",
                principalTable: "Consumable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContract_Employee_EmployeeID",
                table: "DeliveryContract",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContract_Provider_ProviderID",
                table: "DeliveryContract",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContract_PurchaseRequisition_PurchaseRequisitionID",
                table: "DeliveryContract",
                column: "PurchaseRequisitionID",
                principalTable: "PurchaseRequisition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_InventoryType_InventoryTypeID",
                table: "Inventory",
                column: "InventoryTypeID",
                principalTable: "InventoryType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressID",
                table: "Order",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Address_AddressID",
                table: "Provider",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisition_Employee_EmployeeID",
                table: "PurchaseRequisition",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisition_Provider_ProviderID",
                table: "PurchaseRequisition",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisition_RequisitionContent_RequisitionContentID",
                table: "PurchaseRequisition",
                column: "RequisitionContentID",
                principalTable: "RequisitionContent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionContent_Consumable_ConsumableID",
                table: "RequisitionContent",
                column: "ConsumableID",
                principalTable: "Consumable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_InventoryType_InventoryTypeID",
                table: "Service",
                column: "InventoryTypeID",
                principalTable: "InventoryType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrigadeInventory_Brigade_BrigadeID",
                table: "BrigadeInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_BrigadeInventory_Inventory_InventoryID",
                table: "BrigadeInventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumable_ReferenceUnitsOfMeasurement_ReferenceUnitsOfMeas~",
                table: "Consumable");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesService_ConsumptionRate_ConsumptionRateID",
                table: "ConsumablesService");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumablesService_Service_ServiceID",
                table: "ConsumablesService");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumptionRate_Consumable_ConsumableID",
                table: "ConsumptionRate");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsumptionRate_ReferenceUnitsOfMeasurement_ReferenceUnitsO~",
                table: "ConsumptionRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Employee_EmployeeID",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_DeliveryContent_DeliveryContentID",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Provider_ProviderID",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContent_Consumable_ConsumableID",
                table: "DeliveryContent");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContract_Employee_EmployeeID",
                table: "DeliveryContract");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContract_Provider_ProviderID",
                table: "DeliveryContract");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContract_PurchaseRequisition_PurchaseRequisitionID",
                table: "DeliveryContract");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_InventoryType_InventoryTypeID",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_AddressID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Address_AddressID",
                table: "Provider");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisition_Employee_EmployeeID",
                table: "PurchaseRequisition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisition_Provider_ProviderID",
                table: "PurchaseRequisition");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequisition_RequisitionContent_RequisitionContentID",
                table: "PurchaseRequisition");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionContent_Consumable_ConsumableID",
                table: "RequisitionContent");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_InventoryType_InventoryTypeID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_InventoryTypeID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Provider_AddressID",
                table: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_InventoryTypeID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryContract_PurchaseRequisitionID",
                table: "DeliveryContract");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_DeliveryContentID",
                table: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_ConsumptionRate_ReferenceUnitsOfMeasurementID",
                table: "ConsumptionRate");

            migrationBuilder.DropIndex(
                name: "IX_ConsumablesService_ConsumptionRateID",
                table: "ConsumablesService");

            migrationBuilder.DropIndex(
                name: "IX_Consumable_ReferenceUnitsOfMeasurementID",
                table: "Consumable");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brigade",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brigade",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InventoryType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InventoryType",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "InventoryTypeID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "InventoryTypeID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "PurchaseRequisitionID",
                table: "DeliveryContract");

            migrationBuilder.DropColumn(
                name: "DeliveryContentID",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "ReferenceUnitsOfMeasurementID",
                table: "ConsumptionRate");

            migrationBuilder.DropColumn(
                name: "ConsumptionRateID",
                table: "ConsumablesService");

            migrationBuilder.DropColumn(
                name: "ReferenceUnitsOfMeasurementID",
                table: "Consumable");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "Service",
                newName: "Service_Name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "InventoryType",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "UseTime",
                table: "Inventory",
                newName: "Use_Time");

            migrationBuilder.RenameColumn(
                name: "LifeTime",
                table: "Inventory",
                newName: "Life_Time");

            migrationBuilder.RenameColumn(
                name: "InventoryName",
                table: "Inventory",
                newName: "Inventory_Name");

            migrationBuilder.RenameColumn(
                name: "DateOfReceiving",
                table: "Inventory",
                newName: "Date_of_Receiving");

            migrationBuilder.RenameColumn(
                name: "DeliveryContractDate",
                table: "DeliveryContract",
                newName: "Delivery_Contract_Date");

            migrationBuilder.RenameColumn(
                name: "DeliveryContentAmount",
                table: "DeliveryContent",
                newName: "Delivery_Content_Amount");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "Delivery",
                newName: "Delivery_Date");

            migrationBuilder.RenameColumn(
                name: "DeliveryCost",
                table: "Delivery",
                newName: "Delivery_Cost");

            migrationBuilder.RenameColumn(
                name: "DateOfContract",
                table: "Contract",
                newName: "Date_Of_Contract");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Consumable",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "CurrentPrice",
                table: "Consumable",
                newName: "Current_Price");

            migrationBuilder.RenameColumn(
                name: "ConsumableName",
                table: "Consumable",
                newName: "Consumable_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Consumable_ConsumableName",
                table: "Consumable",
                newName: "IX_Consumable_Consumable_Name");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_TypeID",
                table: "Service",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableID",
                table: "RequisitionContent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionContentID",
                table: "PurchaseRequisition",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderID",
                table: "PurchaseRequisition",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "PurchaseRequisition",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ProviderAddressID",
                table: "Provider",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_TypeID",
                table: "Inventory",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderID",
                table: "DeliveryContract",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "DeliveryContract",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Purchase_RequisitionID",
                table: "DeliveryContract",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableID",
                table: "DeliveryContent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderID",
                table: "Delivery",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Delivery_ContentID",
                table: "Delivery",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Contract",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Contract",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableID",
                table: "ConsumptionRate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UnitID",
                table: "ConsumptionRate",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceID",
                table: "ConsumablesService",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Consumption_RateID",
                table: "ConsumablesService",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitID",
                table: "Consumable",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryID",
                table: "BrigadeInventory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BrigadeID",
                table: "BrigadeInventory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Inventory_TypeID",
                table: "Service",
                column: "Inventory_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ProviderAddressID",
                table: "Provider",
                column: "ProviderAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Inventory_TypeID",
                table: "Inventory",
                column: "Inventory_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContract_Purchase_RequisitionID",
                table: "DeliveryContract",
                column: "Purchase_RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Delivery_ContentID",
                table: "Delivery",
                column: "Delivery_ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionRate_UnitID",
                table: "ConsumptionRate",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesService_Consumption_RateID",
                table: "ConsumablesService",
                column: "Consumption_RateID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_UnitID",
                table: "Consumable",
                column: "UnitID");

            migrationBuilder.AddForeignKey(
                name: "FK_BrigadeInventory_Brigade_BrigadeID",
                table: "BrigadeInventory",
                column: "BrigadeID",
                principalTable: "Brigade",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BrigadeInventory_Inventory_InventoryID",
                table: "BrigadeInventory",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumable_ReferenceUnitsOfMeasurement_UnitID",
                table: "Consumable",
                column: "UnitID",
                principalTable: "ReferenceUnitsOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesService_ConsumptionRate_Consumption_RateID",
                table: "ConsumablesService",
                column: "Consumption_RateID",
                principalTable: "ConsumptionRate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumablesService_Service_ServiceID",
                table: "ConsumablesService",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumptionRate_Consumable_ConsumableID",
                table: "ConsumptionRate",
                column: "ConsumableID",
                principalTable: "Consumable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsumptionRate_ReferenceUnitsOfMeasurement_UnitID",
                table: "ConsumptionRate",
                column: "UnitID",
                principalTable: "ReferenceUnitsOfMeasurement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientID",
                table: "Contract",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Employee_EmployeeID",
                table: "Contract",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_DeliveryContent_Delivery_ContentID",
                table: "Delivery",
                column: "Delivery_ContentID",
                principalTable: "DeliveryContent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Provider_ProviderID",
                table: "Delivery",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContent_Consumable_ConsumableID",
                table: "DeliveryContent",
                column: "ConsumableID",
                principalTable: "Consumable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContract_Employee_EmployeeID",
                table: "DeliveryContract",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContract_Provider_ProviderID",
                table: "DeliveryContract",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContract_PurchaseRequisition_Purchase_RequisitionID",
                table: "DeliveryContract",
                column: "Purchase_RequisitionID",
                principalTable: "PurchaseRequisition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_InventoryType_Inventory_TypeID",
                table: "Inventory",
                column: "Inventory_TypeID",
                principalTable: "InventoryType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_AddressID",
                table: "Order",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Address_ProviderAddressID",
                table: "Provider",
                column: "ProviderAddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisition_Employee_EmployeeID",
                table: "PurchaseRequisition",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisition_Provider_ProviderID",
                table: "PurchaseRequisition",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequisition_RequisitionContent_RequisitionContentID",
                table: "PurchaseRequisition",
                column: "RequisitionContentID",
                principalTable: "RequisitionContent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionContent_Consumable_ConsumableID",
                table: "RequisitionContent",
                column: "ConsumableID",
                principalTable: "Consumable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_InventoryType_Inventory_TypeID",
                table: "Service",
                column: "Inventory_TypeID",
                principalTable: "InventoryType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
