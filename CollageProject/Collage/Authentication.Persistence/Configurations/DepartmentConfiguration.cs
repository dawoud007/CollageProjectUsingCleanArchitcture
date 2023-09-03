using Collage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collage.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<CollageDepartment>
    {
        public void Configure(EntityTypeBuilder<CollageDepartment> builder)
        {


            builder.HasOne(d => d.Manager)
          .WithOne()
          .HasForeignKey<CollageDepartment>(d => d.ManagerId)
          .OnDelete(DeleteBehavior.Cascade);

            // Other configurations related to Department
        }
    }

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

        }
    }

}
