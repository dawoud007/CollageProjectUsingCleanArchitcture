using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Collage.Application.Commands.CollageUsers.DeleteCollageUser
{
    public class DeleteCollageUserCommandHandler : IRequestHandler<DeleteCollageUserCommand, ErrorOr<Results>>
    {
        private readonly UserManager<CollageUser> _userManager;

        public DeleteCollageUserCommandHandler(UserManager<CollageUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ErrorOr<Results>> Handle(DeleteCollageUserCommand request, CancellationToken cancellationToken)
        {
            var results = new Results();

            var employeeToDelete = await _userManager.FindByIdAsync(request.CollageUserId.ToString());
            if (employeeToDelete == null)
            {
                results.AddErrorMessages("CollageUser not found");
                return results;
            }

            var deleteResult = await _userManager.DeleteAsync(employeeToDelete);

            if (!deleteResult.Succeeded)
            {
                results.AddErrorMessages(deleteResult.Errors.Select(e => e.Description).ToArray());
                return results;
            }

            results.IsSuccess = true;
            return results;
        }
    }
}
