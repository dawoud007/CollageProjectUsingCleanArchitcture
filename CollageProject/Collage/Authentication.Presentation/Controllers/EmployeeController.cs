using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Employees;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : BaseController<Employee, EmployeeViewModel>
    {
        public EmployeeController(IEmployeeBusiness unitOfWork, IMapper mapper, IValidator<Employee> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
