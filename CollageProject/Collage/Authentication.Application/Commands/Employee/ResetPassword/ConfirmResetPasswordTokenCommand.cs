using Collage.Application.CommandInterfaces;
using ErrorOr;

namespace Collage.Application.Commands.ConfirmResetPasswordToken;
public record ConfirmResetPasswordTokenCommand(
   string CurrentPassword,
        string NewPassword,
        string Email
) : ICommand<ErrorOr<string>>;