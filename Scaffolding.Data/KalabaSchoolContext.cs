using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Scaffolding.Data
{
    public partial class KalabaSchoolContext : DbContext
    {
        public KalabaSchoolContext()
        {
        }

        public KalabaSchoolContext(DbContextOptions<KalabaSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KalabaSchool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.LocationId, "IX_Departments_LocationId");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Students_DepartmentId");

                entity.Property(e => e.FirstName).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasIndex(e => e.CourseId, "IX_StudentCourses_CourseId");

                entity.HasIndex(e => e.StudentId, "IX_StudentCourses_StudentId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_StudentDetails_StudentId")
                    .IsUnique();

                entity.Property(e => e.Income).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.StudentDetail)
                    .HasForeignKey<StudentDetail>(d => d.StudentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
