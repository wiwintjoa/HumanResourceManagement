using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DataAccess.Application;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HrDepartment> HrDepartments { get; set; }

    public virtual DbSet<HrEmployee> HrEmployees { get; set; }

    public virtual DbSet<HrJobHistory> HrJobHistories { get; set; }

    public virtual DbSet<HrLocation> HrLocations { get; set; }

    public virtual DbSet<HrRole> HrRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;user=sa;password=p4s5w0rd;database=HRMS;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HrDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr_Depar__3214EC07F387B7F2");

            entity.ToTable("hr_Department");

            entity.Property(e => e.CreatedBy).HasMaxLength(56);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(56);
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Location).WithMany(p => p.HrDepartments)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_hr_Department_hr_Location");
        });

        modelBuilder.Entity<HrEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr_Emplo__3214EC0772B93C04");

            entity.ToTable("hr_Employee");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(56);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(56);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<HrJobHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr_JobHi__3214EC07E38F385D");

            entity.ToTable("hr_JobHistory");

            entity.Property(e => e.CreatedBy).HasMaxLength(56);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(56);
            entity.Property(e => e.Manager).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Employee).WithMany(p => p.HrJobHistories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_hr_JobHistory_hr_Employee");

            entity.HasOne(d => d.Role).WithMany(p => p.HrJobHistories)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_hr_JobHistory_hr_Role");
        });

        modelBuilder.Entity<HrLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr_Locat__3214EC0710B673E7");

            entity.ToTable("hr_Location");

            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.Country).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasMaxLength(56);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(56);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<HrRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hr_Role__3214EC07841316D8");

            entity.ToTable("hr_Role");

            entity.Property(e => e.CreatedBy).HasMaxLength(56);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(56);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Department).WithMany(p => p.HrRoles)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_hr_Role_hr_Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
