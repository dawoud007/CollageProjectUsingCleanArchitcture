

using AutoMapper;
using Collage.Application.Models.Students;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class StudentsMappings : Profile
{
    public StudentsMappings()
    {
        CreateMap<Student, StudentViewModel>()

        .ReverseMap();
    }
}