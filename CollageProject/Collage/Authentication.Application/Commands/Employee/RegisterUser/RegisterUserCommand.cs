using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser.Enums;
using ErrorOr;

namespace Collage.Application.Commands.RegisterUser;
public record RegisterUserCommand(
    string UserName,
    string Password,
    string Email,
    Gender Gender,
    string Name,
    string ConfirmationLink,
   Role Role
) : ICommand<ErrorOr<Results>>;