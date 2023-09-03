using AutoMapper;
using Collage.Application.Interfaces.businessInterfaces;
using Collage.Application.Models.worker;
using Collage.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WorkerController : BaseController<Worker, WorkerViewModel>
    {
        public WorkerController(IWorkerBusiness unitOfWork, IMapper mapper, IValidator<Worker> validator) : base(unitOfWork, mapper, validator)
        {
        }
    }
}
