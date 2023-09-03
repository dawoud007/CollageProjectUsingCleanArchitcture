using Collage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collage.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Subjects)
                   .WithMany(sub => sub.Students)
                   .UsingEntity(j => j.ToTable("StudentSubjects"));

            // Other configurations related to Student
        }
    }
}
