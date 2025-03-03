using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DB.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Head)
                   .WithOne()
                   .HasForeignKey<Department>(d => d.HeadId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
