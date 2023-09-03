using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class FactulyRepository : BaseRepo<Faculty>, IFacultyRepository
    {
        private readonly ApplicationDbContext _context;
        public FactulyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
