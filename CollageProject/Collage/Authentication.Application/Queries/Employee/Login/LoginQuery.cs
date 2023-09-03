

using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Queries.Login;
public record LoginQuery(
    string UserName,
    string Password
) : IQuery<ErrorOr<Results>>;