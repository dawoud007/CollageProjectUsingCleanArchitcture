using Collage.Application.CommandInterfaces;
using Collage.Application.Interfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using static Collage.Domain.Entities.ApplicationUser.Errors.DomainErrors;

namespace Collage.Application.Queries.SendEmailConfirmation;
public class SendEmailConfirmationQueryHandler : IHandler<SendEmailConfirmationQuery, ErrorOr<Results>>
{
    private readonly UserManager<CollageUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IConfirmationEmailSender _emailSender;

    public SendEmailConfirmationQueryHandler(
        UserManager<CollageUser> userManager,
        IConfiguration configuration,
        IConfirmationEmailSender confirmationEmailSender)
    {
        _userManager = userManager;
        _emailSender = confirmationEmailSender;
        _configuration = configuration;
    }

    public async Task<ErrorOr<Results>> Handle(SendEmailConfirmationQuery request, CancellationToken cancellationToken)
    {
        var DepartManagmentResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            DepartManagmentResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return DepartManagmentResults;
        }
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        try
        {
            await _emailSender.SendConfirmationAsync(toEmail: request.Email, request.ConfirmationLink, token);
            DepartManagmentResults.IsSuccess = true;
        }
        catch
        {
            DepartManagmentResults.AddErrorMessages("Couldn't send confirmation email");
        }
        return DepartManagmentResults;
    }
}
