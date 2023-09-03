

using AutoMapper;
using Collage.Application.Models.Employees;
using Collage.Domain.Entities;

namespace ElectronicsShop_service.MapperProfiles;
public class EmployeeMappings : Profile
{
    public EmployeeMappings()
    {
        CreateMap<Employee, EmployeeViewModel>()

        .ReverseMap();
    }
}