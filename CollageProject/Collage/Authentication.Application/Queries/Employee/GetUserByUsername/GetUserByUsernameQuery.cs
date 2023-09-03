using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Queries.GetUserByUsername;
public record GetUserByUsername(
    string UserName
) : IQuery<ErrorOr<CollageUserViewModel>>;


