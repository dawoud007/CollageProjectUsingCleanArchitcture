

using AutoMapper;
using Collage.Application.Models.worker;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class WorkerMappings : Profile
{
    public WorkerMappings()
    {
        CreateMap<Worker, WorkerViewModel>()

        .ReverseMap();
    }
}