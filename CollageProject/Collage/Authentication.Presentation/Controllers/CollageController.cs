using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.Collage;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CollageController : BaseController<Collages, CollageViewModel>
    {
        public CollageController(ICollageBusiness unitOfWork, IMapper mapper, IValidator<Collages> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
