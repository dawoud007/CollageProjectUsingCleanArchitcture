using Collage.Application.Interfaces;
using Collage.Domain.Entities;
using CommonGenericClasses;

namespace Collage.Persistence.Repositories
{

    public class EmployeeRepository : BaseRepo<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
