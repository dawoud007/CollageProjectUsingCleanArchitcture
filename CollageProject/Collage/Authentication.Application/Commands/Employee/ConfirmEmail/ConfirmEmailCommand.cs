
using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Commands.ConfirmEmail;
public record ConfirmEmailCommand(
    string Email,
    string Token
) : ICommand<ErrorOr<Results>>;