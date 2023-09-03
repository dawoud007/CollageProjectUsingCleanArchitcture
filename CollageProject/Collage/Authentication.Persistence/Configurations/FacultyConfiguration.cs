using Collage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collage.Persistence.Configurations
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasMany(f => f.Students)
                   .WithOne(s => s.Faculty)
                   .HasForeignKey(s => s.FacultyId);

            builder.HasMany(f => f.Professors)
                   .WithOne(p => p.Faculty)
                   .HasForeignKey(p => p.FacultyId);

            builder.HasMany(f => f.Workers)
                   .WithOne(w => w.Faculty)
                   .HasForeignKey(w => w.FacultyId);

            // Other configurations related to Faculty
        }
    }
}