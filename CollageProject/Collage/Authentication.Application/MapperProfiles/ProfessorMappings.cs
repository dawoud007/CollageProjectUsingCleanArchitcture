

using AutoMapper;
using Collage.Application.Models.Professors;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class ProfessorMappings : Profile
{
    public ProfessorMappings()
    {
        CreateMap<Professor, ProfessorViewModel>()

        .ReverseMap();
    }
}