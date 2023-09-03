using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Subjects;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubjectController : BaseController<Subject, SubjectViewModel>
    {
        public SubjectController(ISubjectBusiness unitOfWork, IMapper mapper, IValidator<Subject> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
