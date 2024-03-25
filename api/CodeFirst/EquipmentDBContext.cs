using System;
using System.Collections.Generic;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CodeFirst
{
    public partial class EquipmentDBContext : DbContext
    {
        public EquipmentDBContext()
        {
        }

        public EquipmentDBContext(DbContextOptions<EquipmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Departament> Departaments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<EquipmentRecord> EquipmentRecords { get; set; } = null!;
        public virtual DbSet<EquipmentState> EquipmentStates { get; set; } = null!;
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EquipmentDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(200)
                    .HasColumnName("address");
            });

            modelBuilder.Entity<Departament>(entity =>
            {
                entity.Property(e => e.DepartamentId).HasColumnName("departament_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Departaments)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departaments_Addresses");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DepartamentId, "IX_Employees_DepartamentId");

                entity.HasIndex(e => new { e.Surname, e.Name }, "IX_Employees_Surname_Name");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.DepartamentId).HasColumnName("departament_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Departament)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departaments");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_Equipment_Name");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipment_Equipment");
            });

            modelBuilder.Entity<EquipmentRecord>(entity =>
            {
                entity.ToTable("EquipmentRecords", tb => tb.HasTrigger("EquipmentRecord_Insert"));

                entity.HasIndex(e => e.AccountingCode, "IX_EquipmentRecords_Code");

                entity.HasIndex(e => e.EquipmentId, "IX_EquipmentRecords_EquipmentId");

                entity.HasIndex(e => e.OwnerDepartamentId, "IX_EquipmentRecords_OwnerDepartamentId");

                entity.HasIndex(e => e.OwnerEmployeeId, "IX_EquipmentRecords_OwnerEmployeeId");

                entity.Property(e => e.EquipmentRecordId).HasColumnName("equipment_record_id");

                entity.Property(e => e.AccountingCode)
                    .HasMaxLength(5)
                    .HasColumnName("accounting_code");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.OwnerDepartamentId).HasColumnName("owner_departament_id");

                entity.Property(e => e.OwnerEmployeeId).HasColumnName("owner_employee_id");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("date")
                    .HasColumnName("purchase_date");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentRecords)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentRecords_Equipment");

                entity.HasOne(d => d.OwnerDepartament)
                    .WithMany(p => p.EquipmentRecords)
                    .HasForeignKey(d => d.OwnerDepartamentId)
                    .HasConstraintName("FK_EquipmentRecords_Departaments");

                entity.HasOne(d => d.OwnerEmployee)
                    .WithMany(p => p.EquipmentRecords)
                    .HasForeignKey(d => d.OwnerEmployeeId)
                    .HasConstraintName("FK_EquipmentRecords_Employees");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EquipmentRecords)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentRecords_EquipmentStates");
            });

            modelBuilder.Entity<EquipmentState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EquipmentType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.HasIndex(e => e.Name, "IX_EquipmentTypes_Name");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ParentTypeId).HasColumnName("parent_type_id");

                entity.HasOne(d => d.ParentType)
                    .WithMany(p => p.InverseParentType)
                    .HasForeignKey(d => d.ParentTypeId)
                    .HasConstraintName("FK_EquipmentTypes_EquipmentTypes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
