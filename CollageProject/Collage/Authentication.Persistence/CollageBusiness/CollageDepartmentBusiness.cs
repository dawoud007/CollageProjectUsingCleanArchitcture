using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class CollageDepartmentBusiness : BaseBusiness<CollageDepartment>, ICollageDepartmentBusiness
    {
        public CollageDepartmentBusiness(ICollageDepartmentRepository collageDepartmentRepository) : base(collageDepartmentRepository)
        {
        }
    }
}
