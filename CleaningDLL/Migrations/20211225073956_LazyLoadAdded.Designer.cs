﻿// <auto-generated />
using System;
using CleaningDLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CleaningDLL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211225073956_LazyLoadAdded")]
    partial class LazyLoadAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CleaningDLL.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Apartment_Number")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Building")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Entrance")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CleaningDLL.Brigade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Smena_Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("ID");

                    b.ToTable("Brigade");
                });

            modelBuilder.Entity("CleaningDLL.BrigadeInventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BrigadeID")
                        .HasColumnType("integer");

                    b.Property<int?>("InventoryID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("BrigadeID");

                    b.HasIndex("InventoryID");

                    b.ToTable("BrigadeInventory");
                });

            modelBuilder.Entity("CleaningDLL.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientTelefonNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<bool>("IsOldClient")
                        .HasColumnType("boolean");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.HasIndex("ClientTelefonNumber")
                        .IsUnique();

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CleaningDLL.Consumable", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Consumable_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Current_Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UnitID")
                        .HasColumnType("integer");

                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Consumable_Name")
                        .IsUnique();

                    b.HasIndex("UnitID");

                    b.ToTable("Consumable");
                });

            modelBuilder.Entity("CleaningDLL.ConsumablesService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Consumption_RateID")
                        .HasColumnType("integer");

                    b.Property<int?>("ServiceID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Consumption_RateID");

                    b.HasIndex("ServiceID");

                    b.ToTable("ConsumablesService");
                });

            modelBuilder.Entity("CleaningDLL.ConsumptionRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ConsumableID")
                        .HasColumnType("integer");

                    b.Property<string>("Consumption")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int?>("UnitID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ConsumableID");

                    b.HasIndex("UnitID");

                    b.ToTable("ConsumptionRate");
                });

            modelBuilder.Entity("CleaningDLL.Contract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date_Of_Contract")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("CleaningDLL.Delivery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Delivery_ContentID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Delivery_Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Delivery_Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ProviderID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Delivery_ContentID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("CleaningDLL.DeliveryContent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ConsumableID")
                        .HasColumnType("integer");

                    b.Property<int>("Delivery_Content_Amount")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ConsumableID");

                    b.ToTable("DeliveryContent");
                });

            modelBuilder.Entity("CleaningDLL.DeliveryContract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Delivery_Contract_Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("integer");

                    b.Property<int?>("ProviderID")
                        .HasColumnType("integer");

                    b.Property<int?>("Purchase_RequisitionID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProviderID");

                    b.HasIndex("Purchase_RequisitionID");

                    b.ToTable("DeliveryContract");
                });

            modelBuilder.Entity("CleaningDLL.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BrigadeID")
                        .HasColumnType("integer");

                    b.Property<string>("EmployeeTelefonNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<DateTime>("Employment_Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Password")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("PositionID")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.HasIndex("BrigadeID");

                    b.HasIndex("EmployeeTelefonNumber")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("PassportData")
                        .IsUnique();

                    b.HasIndex("Password")
                        .IsUnique();

                    b.HasIndex("PositionID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CleaningDLL.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date_of_Receiving")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Inventory_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Inventory_TypeID")
                        .HasColumnType("integer");

                    b.Property<string>("Life_Time")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Use_Time")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.HasIndex("Inventory_TypeID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("CleaningDLL.InventoryType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("ID");

                    b.ToTable("InventoryType");
                });

            modelBuilder.Entity("CleaningDLL.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("integer");

                    b.Property<int>("ApproximateTime")
                        .HasColumnType("integer");

                    b.Property<int?>("BrigadeID")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("integer");

                    b.Property<int>("FinalPrice")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("BrigadeID");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CleaningDLL.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("NamePosition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("CleaningDLL.ProvidedService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderID")
                        .HasColumnType("integer");

                    b.Property<int?>("ServiceID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ServiceID");

                    b.ToTable("ProvidedService");
                });

            modelBuilder.Entity("CleaningDLL.Provider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("ProviderAddressID")
                        .HasColumnType("integer");

                    b.Property<string>("ProviderTelefonNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.HasIndex("ProviderAddressID");

                    b.HasIndex("ProviderTelefonNumber")
                        .IsUnique();

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("CleaningDLL.PurchaseRequisition", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("integer");

                    b.Property<int?>("ProviderID")
                        .HasColumnType("integer");

                    b.Property<int?>("RequisitionContentID")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProviderID");

                    b.HasIndex("RequisitionContentID");

                    b.ToTable("PurchaseRequisition");
                });

            modelBuilder.Entity("CleaningDLL.ReferenceUnitsOfMeasurement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("ID");

                    b.HasIndex("Unit")
                        .IsUnique();

                    b.ToTable("ReferenceUnitsOfMeasurement");
                });

            modelBuilder.Entity("CleaningDLL.RequisitionContent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int?>("ConsumableID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ConsumableID");

                    b.ToTable("RequisitionContent");
                });

            modelBuilder.Entity("CleaningDLL.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("Inventory_TypeID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Service_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("Inventory_TypeID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("CleaningDLL.BrigadeInventory", b =>
                {
                    b.HasOne("CleaningDLL.Brigade", "Brigade")
                        .WithMany()
                        .HasForeignKey("BrigadeID");

                    b.HasOne("CleaningDLL.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID");

                    b.Navigation("Brigade");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("CleaningDLL.Consumable", b =>
                {
                    b.HasOne("CleaningDLL.ReferenceUnitsOfMeasurement", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitID");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("CleaningDLL.ConsumablesService", b =>
                {
                    b.HasOne("CleaningDLL.ConsumptionRate", "Consumption_Rate")
                        .WithMany()
                        .HasForeignKey("Consumption_RateID");

                    b.HasOne("CleaningDLL.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID");

                    b.Navigation("Consumption_Rate");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CleaningDLL.ConsumptionRate", b =>
                {
                    b.HasOne("CleaningDLL.Consumable", "Consumable")
                        .WithMany()
                        .HasForeignKey("ConsumableID");

                    b.HasOne("CleaningDLL.ReferenceUnitsOfMeasurement", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitID");

                    b.Navigation("Consumable");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("CleaningDLL.Contract", b =>
                {
                    b.HasOne("CleaningDLL.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("CleaningDLL.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CleaningDLL.Delivery", b =>
                {
                    b.HasOne("CleaningDLL.DeliveryContent", "Delivery_Content")
                        .WithMany()
                        .HasForeignKey("Delivery_ContentID");

                    b.HasOne("CleaningDLL.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID");

                    b.Navigation("Delivery_Content");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("CleaningDLL.DeliveryContent", b =>
                {
                    b.HasOne("CleaningDLL.Consumable", "Consumable")
                        .WithMany()
                        .HasForeignKey("ConsumableID");

                    b.Navigation("Consumable");
                });

            modelBuilder.Entity("CleaningDLL.DeliveryContract", b =>
                {
                    b.HasOne("CleaningDLL.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("CleaningDLL.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID");

                    b.HasOne("CleaningDLL.PurchaseRequisition", "Purchase_Requisition")
                        .WithMany()
                        .HasForeignKey("Purchase_RequisitionID");

                    b.Navigation("Employee");

                    b.Navigation("Provider");

                    b.Navigation("Purchase_Requisition");
                });

            modelBuilder.Entity("CleaningDLL.Employee", b =>
                {
                    b.HasOne("CleaningDLL.Brigade", "Brigade")
                        .WithMany()
                        .HasForeignKey("BrigadeID");

                    b.HasOne("CleaningDLL.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brigade");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("CleaningDLL.Inventory", b =>
                {
                    b.HasOne("CleaningDLL.InventoryType", "Inventory_Type")
                        .WithMany()
                        .HasForeignKey("Inventory_TypeID");

                    b.Navigation("Inventory_Type");
                });

            modelBuilder.Entity("CleaningDLL.Order", b =>
                {
                    b.HasOne("CleaningDLL.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("CleaningDLL.Brigade", "Brigade")
                        .WithMany()
                        .HasForeignKey("BrigadeID");

                    b.HasOne("CleaningDLL.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("CleaningDLL.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Address");

                    b.Navigation("Brigade");

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CleaningDLL.ProvidedService", b =>
                {
                    b.HasOne("CleaningDLL.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.HasOne("CleaningDLL.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceID");

                    b.Navigation("Order");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CleaningDLL.Provider", b =>
                {
                    b.HasOne("CleaningDLL.Address", "ProviderAddress")
                        .WithMany()
                        .HasForeignKey("ProviderAddressID");

                    b.Navigation("ProviderAddress");
                });

            modelBuilder.Entity("CleaningDLL.PurchaseRequisition", b =>
                {
                    b.HasOne("CleaningDLL.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("CleaningDLL.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID");

                    b.HasOne("CleaningDLL.RequisitionContent", "RequisitionContent")
                        .WithMany()
                        .HasForeignKey("RequisitionContentID");

                    b.Navigation("Employee");

                    b.Navigation("Provider");

                    b.Navigation("RequisitionContent");
                });

            modelBuilder.Entity("CleaningDLL.RequisitionContent", b =>
                {
                    b.HasOne("CleaningDLL.Consumable", "Consumable")
                        .WithMany()
                        .HasForeignKey("ConsumableID");

                    b.Navigation("Consumable");
                });

            modelBuilder.Entity("CleaningDLL.Service", b =>
                {
                    b.HasOne("CleaningDLL.InventoryType", "Inventory_Type")
                        .WithMany()
                        .HasForeignKey("Inventory_TypeID");

                    b.Navigation("Inventory_Type");
                });

            modelBuilder.Entity("CleaningDLL.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
