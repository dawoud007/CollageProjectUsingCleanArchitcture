using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class SubjectRepository : BaseRepo<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
