using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class FacultyBusiness : BaseBusiness<Faculty>, IFactulyBusiness
    {
        public FacultyBusiness(IFacultyRepository facultyRpository) : base(facultyRpository)
        {
        }
    }
}
