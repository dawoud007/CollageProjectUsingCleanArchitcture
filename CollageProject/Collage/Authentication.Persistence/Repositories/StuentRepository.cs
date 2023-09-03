using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class StuentRepository : BaseRepo<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StuentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
