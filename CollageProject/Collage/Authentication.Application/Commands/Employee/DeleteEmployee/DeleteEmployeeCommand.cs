using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Commands.CollageUsers.DeleteCollageUser
{

    public record DeleteCollageUserCommand(
  string CollageUserId

) : ICommand<ErrorOr<Results>>;
}
