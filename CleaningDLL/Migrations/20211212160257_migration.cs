using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CleaningDLL.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HouseNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Building = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Entrance = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Apartment_Number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Brigade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Smena_Number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClientTelefonNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamePosition = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceUnitsOfMeasurement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Unit = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceUnitsOfMeasurement", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProviderTelefonNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ProviderAddressID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Provider_Address_ProviderAddressID",
                        column: x => x.ProviderAddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Inventory_Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Inventory_TypeID = table.Column<int>(type: "integer", nullable: true),
                    Use_Time = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Life_Time = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Date_of_Receiving = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryType_Inventory_TypeID",
                        column: x => x.Inventory_TypeID,
                        principalTable: "InventoryType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Service_Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Inventory_TypeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Service_InventoryType_Inventory_TypeID",
                        column: x => x.Inventory_TypeID,
                        principalTable: "InventoryType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PassportData = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    EmployeeTelefonNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    PositionID = table.Column<int>(type: "integer", nullable: false),
                    BrigadeID = table.Column<int>(type: "integer", nullable: true),
                    Employment_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Brigade_BrigadeID",
                        column: x => x.BrigadeID,
                        principalTable: "Brigade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Consumable_Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Current_Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UnitID = table.Column<int>(type: "integer", nullable: true),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consumable_ReferenceUnitsOfMeasurement_UnitID",
                        column: x => x.UnitID,
                        principalTable: "ReferenceUnitsOfMeasurement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrigadeInventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrigadeID = table.Column<int>(type: "integer", nullable: true),
                    InventoryID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrigadeInventory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BrigadeInventory_Brigade_BrigadeID",
                        column: x => x.BrigadeID,
                        principalTable: "Brigade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrigadeInventory_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeID = table.Column<int>(type: "integer", nullable: true),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    Date_Of_Contract = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contract_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    EmployeeID = table.Column<int>(type: "integer", nullable: true),
                    AddressID = table.Column<int>(type: "integer", nullable: true),
                    BrigadeID = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Brigade_BrigadeID",
                        column: x => x.BrigadeID,
                        principalTable: "Brigade",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionRate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Consumption = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ConsumableID = table.Column<int>(type: "integer", nullable: true),
                    UnitID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsumptionRate_Consumable_ConsumableID",
                        column: x => x.ConsumableID,
                        principalTable: "Consumable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumptionRate_ReferenceUnitsOfMeasurement_UnitID",
                        column: x => x.UnitID,
                        principalTable: "ReferenceUnitsOfMeasurement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryContent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConsumableID = table.Column<int>(type: "integer", nullable: true),
                    Delivery_Content_Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryContent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeliveryContent_Consumable_ConsumableID",
                        column: x => x.ConsumableID,
                        principalTable: "Consumable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionContent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConsumableID = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionContent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RequisitionContent_Consumable_ConsumableID",
                        column: x => x.ConsumableID,
                        principalTable: "Consumable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvidedService",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderID = table.Column<int>(type: "integer", nullable: true),
                    ServiceID = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    ReferenceUnitsOfMeasurementID = table.Column<int>(type: "integer", nullable: true),
                    InventoryID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedService", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProvidedService_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidedService_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidedService_ReferenceUnitsOfMeasurement_ReferenceUnitsO~",
                        column: x => x.ReferenceUnitsOfMeasurementID,
                        principalTable: "ReferenceUnitsOfMeasurement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidedService_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumablesService",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceID = table.Column<int>(type: "integer", nullable: true),
                    Consumption_RateID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablesService", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsumablesService_ConsumptionRate_Consumption_RateID",
                        column: x => x.Consumption_RateID,
                        principalTable: "ConsumptionRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumablesService_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProviderID = table.Column<int>(type: "integer", nullable: true),
                    Delivery_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Delivery_Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    Delivery_ContentID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryContent_Delivery_ContentID",
                        column: x => x.Delivery_ContentID,
                        principalTable: "DeliveryContent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Delivery_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<int>(type: "integer", nullable: true),
                    ProviderID = table.Column<int>(type: "integer", nullable: true),
                    RequisitionContentID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisition_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisition_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisition_RequisitionContent_RequisitionContentID",
                        column: x => x.RequisitionContentID,
                        principalTable: "RequisitionContent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryContract",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeID = table.Column<int>(type: "integer", nullable: true),
                    ProviderID = table.Column<int>(type: "integer", nullable: true),
                    Purchase_RequisitionID = table.Column<int>(type: "integer", nullable: true),
                    Delivery_Contract_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryContract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeliveryContract_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryContract_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Provider",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryContract_PurchaseRequisition_Purchase_RequisitionID",
                        column: x => x.Purchase_RequisitionID,
                        principalTable: "PurchaseRequisition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeInventory_BrigadeID",
                table: "BrigadeInventory",
                column: "BrigadeID");

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeInventory_InventoryID",
                table: "BrigadeInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTelefonNumber",
                table: "Client",
                column: "ClientTelefonNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_Consumable_Name",
                table: "Consumable",
                column: "Consumable_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumable_UnitID",
                table: "Consumable",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesService_Consumption_RateID",
                table: "ConsumablesService",
                column: "Consumption_RateID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablesService_ServiceID",
                table: "ConsumablesService",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionRate_ConsumableID",
                table: "ConsumptionRate",
                column: "ConsumableID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionRate_UnitID",
                table: "ConsumptionRate",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientID",
                table: "Contract",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EmployeeID",
                table: "Contract",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Delivery_ContentID",
                table: "Delivery",
                column: "Delivery_ContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_ProviderID",
                table: "Delivery",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContent_ConsumableID",
                table: "DeliveryContent",
                column: "ConsumableID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContract_EmployeeID",
                table: "DeliveryContract",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContract_ProviderID",
                table: "DeliveryContract",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContract_Purchase_RequisitionID",
                table: "DeliveryContract",
                column: "Purchase_RequisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BrigadeID",
                table: "Employee",
                column: "BrigadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTelefonNumber",
                table: "Employee",
                column: "EmployeeTelefonNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Login",
                table: "Employee",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PassportData",
                table: "Employee",
                column: "PassportData",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Password",
                table: "Employee",
                column: "Password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionID",
                table: "Employee",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Inventory_TypeID",
                table: "Inventory",
                column: "Inventory_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressID",
                table: "Order",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BrigadeID",
                table: "Order",
                column: "BrigadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_InventoryID",
                table: "ProvidedService",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_OrderID",
                table: "ProvidedService",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_ReferenceUnitsOfMeasurementID",
                table: "ProvidedService",
                column: "ReferenceUnitsOfMeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedService_ServiceID",
                table: "ProvidedService",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_CompanyName",
                table: "Provider",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ProviderAddressID",
                table: "Provider",
                column: "ProviderAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_ProviderTelefonNumber",
                table: "Provider",
                column: "ProviderTelefonNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisition_EmployeeID",
                table: "PurchaseRequisition",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisition_ProviderID",
                table: "PurchaseRequisition",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisition_RequisitionContentID",
                table: "PurchaseRequisition",
                column: "RequisitionContentID");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceUnitsOfMeasurement_Unit",
                table: "ReferenceUnitsOfMeasurement",
                column: "Unit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionContent_ConsumableID",
                table: "RequisitionContent",
                column: "ConsumableID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Inventory_TypeID",
                table: "Service",
                column: "Inventory_TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrigadeInventory");

            migrationBuilder.DropTable(
                name: "ConsumablesService");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "DeliveryContract");

            migrationBuilder.DropTable(
                name: "ProvidedService");

            migrationBuilder.DropTable(
                name: "ConsumptionRate");

            migrationBuilder.DropTable(
                name: "DeliveryContent");

            migrationBuilder.DropTable(
                name: "PurchaseRequisition");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "RequisitionContent");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "InventoryType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Consumable");

            migrationBuilder.DropTable(
                name: "Brigade");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "ReferenceUnitsOfMeasurement");
        }
    }
}
