using Collage.Application.CommandInterfaces;
using Collage.Application.Interfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using static Collage.Domain.Entities.ApplicationUser.Errors.DomainErrors;

namespace Collage.Application.Queries.SendEmailResetPassword;
public class SendEmailResetPasswordQueryHandler : IHandler<SendEmailResetPasswordQuery, ErrorOr<Results>>
{
    private readonly UserManager<CollageUser> _userManager;
    private readonly IResetPasswordEmailSender _emailSender;
    public SendEmailResetPasswordQueryHandler(UserManager<CollageUser> userManager, IResetPasswordEmailSender resetPasswordEmailSender)
    {
        _userManager = userManager;
        _emailSender = resetPasswordEmailSender;
    }

    public async Task<ErrorOr<Results>> Handle(SendEmailResetPasswordQuery request, CancellationToken cancellationToken)
    {
        var DepartManagmentResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            DepartManagmentResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return DepartManagmentResults;
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        try
        {
            await _emailSender.SendPasswordResetAsync(toEmail: request.Email, token);
            DepartManagmentResults.IsSuccess = true;
        }
        catch
        {
            DepartManagmentResults.AddErrorMessages("Couldn't send change password email");
        }
        return DepartManagmentResults;
    }
}
