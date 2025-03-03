using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApplication1.DB.Configurations;
using WebApplication1.Models;
namespace WebApplication1.DB
{
    public class TeacherDBContext:DbContext
    {
        DbSet<AcademicDegree> AcademicDegrees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Workload> Workloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }

        public TeacherDBContext(DbContextOptions<TeacherDBContext> options) : base(options)
        {

        }
    }
}
