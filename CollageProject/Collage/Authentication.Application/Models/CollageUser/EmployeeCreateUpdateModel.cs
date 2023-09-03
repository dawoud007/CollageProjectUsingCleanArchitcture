using Collage.Domain.Entities.ApplicationUser.Enums;

namespace Collage.Application.Models.CollageUsers;
public record CollageUserCreateUpdateModel(
    string Name,
    string Email,
    string Password,
    string UserName,
    Gender Gender,
    Role Role
    );