using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Professors;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProfessorController : BaseController<Professor, ProfessorViewModel>
    {
        public ProfessorController(IProfessorBusiness unitOfWork, IMapper mapper, IValidator<Professor> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
