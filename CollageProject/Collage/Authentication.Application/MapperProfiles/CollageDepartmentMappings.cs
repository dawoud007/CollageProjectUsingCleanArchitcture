

using AutoMapper;
using Collage.Application.Models.Department;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class CollageDepartmentMappings : Profile
{
    public CollageDepartmentMappings()
    {
        CreateMap<CollageDepartment, CollageDepartmentViewModel>()

        .ReverseMap();
    }
}