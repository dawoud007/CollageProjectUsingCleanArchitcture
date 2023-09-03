using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Queries.SendEmailConfirmation;
public record SendEmailConfirmationQuery(
    string Email,
    string ConfirmationLink
) : IQuery<ErrorOr<Results>>;