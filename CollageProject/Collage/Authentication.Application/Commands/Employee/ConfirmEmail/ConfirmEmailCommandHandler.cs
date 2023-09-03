using Collage.Application.CommandInterfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using static Collage.Domain.Entities.ApplicationUser.Errors.DomainErrors;

namespace Collage.Application.Commands.ConfirmEmail;
public class ConfirmEmailCommandHandler : IHandler<ConfirmEmailCommand, ErrorOr<Results>>
{
    private readonly UserManager<CollageUser> _userManager;

    public ConfirmEmailCommandHandler(UserManager<CollageUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ErrorOr<Results>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var DepartManagmentResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            DepartManagmentResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return DepartManagmentResults;
        }
        var result = await _userManager.ConfirmEmailAsync(user, request.Token);
        if (!result.Succeeded)
        {
            DepartManagmentResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
            return DepartManagmentResults;
        }


        DepartManagmentResults.IsSuccess = true;


        return DepartManagmentResults;
    }
}