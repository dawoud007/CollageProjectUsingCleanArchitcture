using Collage.Domain.Entities.ApplicationUser;
using Collage.Domain.Entities.ApplicationUser.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collage.Persistence.Configurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<CollageUser>
{
    public void Configure(EntityTypeBuilder<CollageUser> builder)
    {
        builder.ToTable("collageusers");
        builder.Property(u => u.Gender).HasDefaultValue(Gender.Male);
    }
}