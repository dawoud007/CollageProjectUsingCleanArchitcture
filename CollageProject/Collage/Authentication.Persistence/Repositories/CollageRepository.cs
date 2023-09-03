using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class CollageRepository : BaseRepo<Collages>, ICollageRepository
    {
        private readonly ApplicationDbContext _context;
        public CollageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
