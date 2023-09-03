using Collage.Application.Interfaces;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Domain.Commons.UnitOfWork;
using Collage.Domain.Entities;

namespace Collage.Persistence.CollageBusiness
{
    public class StudentBusiness : BaseBusiness<Student>, IStudentBusiness
    {
        public StudentBusiness(IStudentRepository studentRepository) : base(studentRepository)
        {
        }
    }
}
