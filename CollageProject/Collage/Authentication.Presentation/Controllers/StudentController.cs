using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Students;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : BaseController<Student, StudentViewModel>
    {
        public StudentController(IStudentBusiness unitOfWork, IMapper mapper, IValidator<Student> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
