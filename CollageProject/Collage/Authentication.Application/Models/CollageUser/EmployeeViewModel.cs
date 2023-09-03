using Collage.Domain.Entities.ApplicationUser.Enums;

namespace Collage.Application.Models.CollageUsers;
public record CollageUserViewModel(
    string Id,
    string Name,
    string Email,
    string UserName,
    Gender Gender,
    Role Role,
   string DepartmentName


    );
