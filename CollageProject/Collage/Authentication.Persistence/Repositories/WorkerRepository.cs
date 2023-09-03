using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class WorkerRepository : BaseRepo<Worker>, IWorkerRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
