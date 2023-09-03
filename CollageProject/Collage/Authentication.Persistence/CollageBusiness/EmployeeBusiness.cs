using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class EmployeeBusiness : BaseBusiness<Employee>, IEmployeeBusiness
    {
        public EmployeeBusiness(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
        }
    }
}
