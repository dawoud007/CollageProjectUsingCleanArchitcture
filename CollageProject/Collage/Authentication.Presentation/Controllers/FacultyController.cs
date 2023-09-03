using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Faculties;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacultyController : BaseController<Faculty, FacultyViewModel>
    {
        public FacultyController(IFactulyBusiness unitOfWork, IMapper mapper, IValidator<Faculty> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
