using Collage.Application.Interfaces;
using Collage.Domain.Entities.ApplicationUser;

namespace Collage.Persistence.Repositories
{

    public class CollageUserRepository : BaseRepoForIdentity<CollageUser>, ICollageUserRepository
    {
        private readonly ApplicationDbContext _context;
        public CollageUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
