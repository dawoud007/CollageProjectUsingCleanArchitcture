using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Department;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepartmentController : BaseController<CollageDepartment, CollageDepartmentViewModel>
    {
        public DepartmentController(ICollageDepartmentBusiness unitOfWork, IMapper mapper, IValidator<CollageDepartment> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
