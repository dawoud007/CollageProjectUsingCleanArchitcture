using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Queries.SendEmailResetPassword;
public record SendEmailResetPasswordQuery(
    string Email
) : IQuery<ErrorOr<Results>>;