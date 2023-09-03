

using AutoMapper;
using Collage.Application.Models.Faculties;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class FacultyMappings : Profile
{
    public FacultyMappings()
    {
        CreateMap<Faculty, FacultyViewModel>()

        .ReverseMap();
    }
}