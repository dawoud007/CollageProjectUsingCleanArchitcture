using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Collage.Application.Commands.CollageUsers.UpdateCollageUser
{
    public class UpdateCollageUserCommandHandler : IRequestHandler<UpdateCollageUserCommand, ErrorOr<Results>>
    {
        private readonly UserManager<CollageUser> _userManager;

        public UpdateCollageUserCommandHandler(UserManager<CollageUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ErrorOr<Results>> Handle(UpdateCollageUserCommand request, CancellationToken cancellationToken)
        {
            var results = new Results();

            var existingCollageUser = await _userManager.FindByIdAsync(request.CollageUserId.ToString());
            if (existingCollageUser == null)
            {
                results.AddErrorMessages("CollageUser not found");
                return results;
            }

            existingCollageUser.Name = request.CollageUserUpdateModel.Name;
            existingCollageUser.Email = request.CollageUserUpdateModel.Email;
            existingCollageUser.UserName = request.CollageUserUpdateModel.UserName;
            existingCollageUser.Gender = request.CollageUserUpdateModel.Gender;
            existingCollageUser.Role = request.CollageUserUpdateModel.Role;


            var updateResult = await _userManager.UpdateAsync(existingCollageUser);

            if (!updateResult.Succeeded)
            {
                results.AddErrorMessages(updateResult.Errors.Select(e => e.Description).ToArray());
                return results;
            }

            results.IsSuccess = true;
            return results;
        }
    }
}
