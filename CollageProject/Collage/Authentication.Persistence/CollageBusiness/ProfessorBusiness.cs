using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class ProfessorBusiness : BaseBusiness<Professor>, IProfessorBusiness
    {
        public ProfessorBusiness(IProfessorRepository professorRepository) : base(professorRepository)
        {
        }
    }
}
