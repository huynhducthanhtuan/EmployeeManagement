using EmployeeService.DTO;
using EmployeeService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() {}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        /// Entities ///
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        /// DTOs ///
        public virtual DbSet<EmployeeDTO> EmployeeDTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// Entities ///
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED1321BF53");

                entity.Property(e => e.DepartmentId).HasDefaultValueSql("(lower(newid()))");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F1163CAE5C0");

                entity.Property(e => e.EmployeeId).HasDefaultValueSql("(lower(newid()))");
                entity.Property(e => e.AvatarImage).HasDefaultValueSql("(NULL)");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DepartmentId).HasMaxLength(450);
                entity.Property(e => e.Gender).HasDefaultValue("Other");
                entity.Property(e => e.PositionId).HasMaxLength(450);

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Depar__16CE6296");

                entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Posit__17C286CF");
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId }).HasName("PK__Employee__6DB1E4FE24C8CF4C");

                entity.Property(e => e.AssignedDate).HasDefaultValueSql("(lower(newid()))");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.PositionId).HasMaxLength(450);

                entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Emplo__2334397B");

                entity.HasOne(d => d.Position).WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Posit__251C81ED");

                entity.HasOne(d => d.Project).WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Proje__24285DB4");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A79C50B0A5F");

                entity.Property(e => e.PositionId).HasDefaultValueSql("(lower(newid()))");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF0172BB073");

                entity.Property(e => e.ProjectId).HasDefaultValueSql("(lower(newid()))");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DepartmentId).HasMaxLength(450);

                entity.HasOne(d => d.Department).WithMany(p => p.Projects)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projects__Depart__1D7B6025");
            });

            /// DTOs ///
            modelBuilder.Entity<EmployeeDTO>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
