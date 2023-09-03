using Collage.Domain.Entities.ApplicationUser.Enums;
using Microsoft.AspNetCore.Identity;

namespace Collage.Domain.Entities.ApplicationUser
{
    public class CollageUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Role Role { get; set; }



    }
}
