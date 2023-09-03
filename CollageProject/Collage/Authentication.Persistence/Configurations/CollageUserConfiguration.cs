using Collage.Domain.Entities.ApplicationUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collage.Persistence.Configurations
{
    public class CollageUserConfiguration : IEntityTypeConfiguration<CollageUser>
    {
        public void Configure(EntityTypeBuilder<CollageUser> builder)
        {





        }
    }

}
