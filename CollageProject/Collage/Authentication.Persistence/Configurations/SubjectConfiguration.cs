using Collage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collage.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(sub => sub.Id);

            builder.HasOne(sub => sub.Professor)
                   .WithMany(p => p.Subjects)
                   .HasForeignKey(sub => sub.ProfessorId);

            // Other configurations related to Subject
        }
    }
}
