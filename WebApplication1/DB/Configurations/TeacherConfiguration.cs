using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DB.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Department)
                   .WithMany(d => d.Teachers)
                   .HasForeignKey(t => t.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Degree)
                   .WithMany(a => a.Teachers)
                   .HasForeignKey(t => t.DegreeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Position)
                   .WithMany(p => p.Teachers)
                   .HasForeignKey(t => t.PositionId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
