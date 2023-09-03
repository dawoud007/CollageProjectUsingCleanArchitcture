

using AutoMapper;
using Collage.Application.Models.Subjects;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class SubjectMappings : Profile
{
    public SubjectMappings()
    {
        CreateMap<Subject, SubjectViewModel>()

        .ReverseMap();
    }
}