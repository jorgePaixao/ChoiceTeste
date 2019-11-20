using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HumanResources.Models
{
    public partial class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext()
        {
        }

        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-IQECTBL\\SQLEXPRESS;Initial Catalog=HumanResources;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("DEPARTMENTS");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");

                entity.Property(e => e.ManagerId).HasColumnName("MANAGER_ID");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EMPLOYEES");

                entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ComissionPct).HasColumnName("COMISSION_PCT");

                entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDdate)
                    .HasColumnName("HIRE_DDATE")
                    .HasColumnType("date");

                entity.Property(e => e.JobId)
                    .HasColumnName("JOB_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId).HasColumnName("MANAGER_ID");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("PHONE_NUMBER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.ToTable("JOBS");

                entity.Property(e => e.JobId).HasColumnName("JOB_ID");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("JOB_TITLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxSalary)
                    .HasColumnName("MAX_SALARY")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinSalary)
                    .HasColumnName("MIN_SALARY")
                    .HasColumnType("decimal(18, 0)");
            });
        }
    }
}
