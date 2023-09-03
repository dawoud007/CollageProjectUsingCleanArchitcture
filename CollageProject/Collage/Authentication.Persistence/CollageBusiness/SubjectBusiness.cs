using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class SubjectBusiness : BaseBusiness<Subject>, ISubjectBusiness
    {
        public SubjectBusiness(ISubjectRepository cartRepository) : base(cartRepository)
        {
        }
    }
}
