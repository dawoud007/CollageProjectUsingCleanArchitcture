using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class CollageDepartmentRepository : BaseRepo<CollageDepartment>, ICollageDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public CollageDepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
