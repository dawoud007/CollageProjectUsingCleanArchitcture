using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class ProfessorRepository : BaseRepo<Professor>, IProfessorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
