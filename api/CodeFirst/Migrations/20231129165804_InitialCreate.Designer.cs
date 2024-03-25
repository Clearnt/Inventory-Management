﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirst.Migrations
{
    [DbContext(typeof(EquipmentDBContext))]
    [Migration("20231129165804_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CodeFirst.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("address_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("address");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CodeFirst.Models.Departament", b =>
                {
                    b.Property<int>("DepartamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("departament_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentId"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("address_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("DepartamentId");

                    b.HasIndex("AddressId");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("CodeFirst.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int")
                        .HasColumnName("departament_id");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email_address");

                    b.Property<string>("HomeAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("home_address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone_number");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("position");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("surname");

                    b.HasKey("EmployeeId");

                    b.HasIndex(new[] { "DepartamentId" }, "IX_Employees_DepartamentId");

                    b.HasIndex(new[] { "Surname", "Name" }, "IX_Employees_Surname_Name");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CodeFirst.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("equipment_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.HasKey("EquipmentId");

                    b.HasIndex("TypeId");

                    b.HasIndex(new[] { "Name" }, "IX_Equipment_Name");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentRecord", b =>
                {
                    b.Property<int>("EquipmentRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("equipment_record_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipmentRecordId"), 1L, 1);

                    b.Property<string>("AccountingCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("accounting_code");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money")
                        .HasColumnName("cost");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int")
                        .HasColumnName("equipment_id");

                    b.Property<int?>("OwnerDepartamentId")
                        .HasColumnType("int")
                        .HasColumnName("owner_departament_id");

                    b.Property<int?>("OwnerEmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("owner_employee_id");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("date")
                        .HasColumnName("purchase_date");

                    b.Property<int?>("PurchaseYear")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasColumnName("purchase_year")
                        .HasComputedColumnSql("(datepart(year,[purchase_date]))", false);

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("state_id");

                    b.HasKey("EquipmentRecordId");

                    b.HasIndex("StateId");

                    b.HasIndex(new[] { "PurchaseYear" }, "IX_EquipmentRecords_Age");

                    b.HasIndex(new[] { "AccountingCode" }, "IX_EquipmentRecords_Code");

                    b.HasIndex(new[] { "EquipmentId" }, "IX_EquipmentRecords_EquipmentId");

                    b.HasIndex(new[] { "OwnerDepartamentId" }, "IX_EquipmentRecords_OwnerDepartamentId");

                    b.HasIndex(new[] { "OwnerEmployeeId" }, "IX_EquipmentRecords_OwnerEmployeeId");

                    b.ToTable("EquipmentRecords");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentState", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("state_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("StateId");

                    b.ToTable("EquipmentStates");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("ParentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("parent_type_id");

                    b.HasKey("TypeId");

                    b.HasIndex("ParentTypeId");

                    b.HasIndex(new[] { "Name" }, "IX_EquipmentTypes_Name");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("CodeFirst.Models.Departament", b =>
                {
                    b.HasOne("CodeFirst.Models.Address", "Address")
                        .WithMany("Departaments")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Departaments_Addresses");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CodeFirst.Models.Employee", b =>
                {
                    b.HasOne("CodeFirst.Models.Departament", "Departament")
                        .WithMany("Employees")
                        .HasForeignKey("DepartamentId")
                        .IsRequired()
                        .HasConstraintName("FK_Employees_Departaments");

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("CodeFirst.Models.Equipment", b =>
                {
                    b.HasOne("CodeFirst.Models.EquipmentType", "Type")
                        .WithMany("Equipment")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Equipment_Equipment");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentRecord", b =>
                {
                    b.HasOne("CodeFirst.Models.Equipment", "Equipment")
                        .WithMany("EquipmentRecords")
                        .HasForeignKey("EquipmentId")
                        .IsRequired()
                        .HasConstraintName("FK_EquipmentRecords_Equipment");

                    b.HasOne("CodeFirst.Models.Departament", "OwnerDepartament")
                        .WithMany("EquipmentRecords")
                        .HasForeignKey("OwnerDepartamentId")
                        .HasConstraintName("FK_EquipmentRecords_Departaments");

                    b.HasOne("CodeFirst.Models.Employee", "OwnerEmployee")
                        .WithMany("EquipmentRecords")
                        .HasForeignKey("OwnerEmployeeId")
                        .HasConstraintName("FK_EquipmentRecords_Employees");

                    b.HasOne("CodeFirst.Models.EquipmentState", "State")
                        .WithMany("EquipmentRecords")
                        .HasForeignKey("StateId")
                        .IsRequired()
                        .HasConstraintName("FK_EquipmentRecords_EquipmentStates");

                    b.Navigation("Equipment");

                    b.Navigation("OwnerDepartament");

                    b.Navigation("OwnerEmployee");

                    b.Navigation("State");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentType", b =>
                {
                    b.HasOne("CodeFirst.Models.EquipmentType", "ParentType")
                        .WithMany("InverseParentType")
                        .HasForeignKey("ParentTypeId")
                        .HasConstraintName("FK_EquipmentTypes_EquipmentTypes");

                    b.Navigation("ParentType");
                });

            modelBuilder.Entity("CodeFirst.Models.Address", b =>
                {
                    b.Navigation("Departaments");
                });

            modelBuilder.Entity("CodeFirst.Models.Departament", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("EquipmentRecords");
                });

            modelBuilder.Entity("CodeFirst.Models.Employee", b =>
                {
                    b.Navigation("EquipmentRecords");
                });

            modelBuilder.Entity("CodeFirst.Models.Equipment", b =>
                {
                    b.Navigation("EquipmentRecords");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentState", b =>
                {
                    b.Navigation("EquipmentRecords");
                });

            modelBuilder.Entity("CodeFirst.Models.EquipmentType", b =>
                {
                    b.Navigation("Equipment");

                    b.Navigation("InverseParentType");
                });
#pragma warning restore 612, 618
        }
    }
}
