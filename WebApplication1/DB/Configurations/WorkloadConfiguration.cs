using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DB.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.HasKey(w => w.Id);
            builder.HasOne(w => w.Teacher)
                   .WithMany(t => t.Workloads)
                   .HasForeignKey(w => w.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(w => w.Subject)
                   .WithMany(s => s.Workloads)
                   .HasForeignKey(w => w.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(w => w.Department)
                   .WithMany(d => d.Workloads)
                   .HasForeignKey(w => w.DepartmentId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
