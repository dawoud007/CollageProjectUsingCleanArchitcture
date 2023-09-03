

using AutoMapper;
using Collage.Application.Models.Collage;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class CollagesMappings : Profile
{
    public CollagesMappings()
    {
        CreateMap<Collages, CollageViewModel>()

        .ReverseMap();
    }
}