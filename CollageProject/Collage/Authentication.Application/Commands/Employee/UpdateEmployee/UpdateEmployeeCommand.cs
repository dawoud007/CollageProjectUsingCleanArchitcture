using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using ErrorOr;

namespace Collage.Application.Commands.CollageUsers.UpdateCollageUser
{
    public record UpdateCollageUserCommand(
      string CollageUserId,
   CollageUserCreateUpdateModel CollageUserUpdateModel
) : ICommand<ErrorOr<Results>>;

}
