using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DB.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DegreeName).IsRequired();
        }
    }

}
