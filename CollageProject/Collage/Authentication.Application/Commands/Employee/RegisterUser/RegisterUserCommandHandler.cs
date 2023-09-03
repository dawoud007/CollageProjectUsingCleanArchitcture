using Collage.Application.CommandInterfaces;
using Collage.Application.Interfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Identity;
using static Collage.Domain.Entities.ApplicationUser.Errors.DomainErrors;

namespace Collage.Application.Commands.RegisterUser;
public class RegisterUserCommandHandler : IHandler<RegisterUserCommand, ErrorOr<Results>>
{
    private readonly UserManager<CollageUser> _userManager;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IConfirmationEmailSender _emailSender;

    public RegisterUserCommandHandler(
        UserManager<CollageUser> userManager,
        IConfirmationEmailSender confirmationEmailSender,
        ITokenGenerator tokenGenerator
        )
    {
        _emailSender = confirmationEmailSender;
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ErrorOr<Results>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var DepartManagmentResults = new Results();
        var user = request.Adapt<CollageUser>();
        if (await _userManager.FindByNameAsync(user.UserName) is not null)
        {
            DepartManagmentResults.AddErrorMessages(UserErrors.UserNameAlreadyExists);
        }
        if (await _userManager.FindByEmailAsync(user.Email) is not null)
        {
            DepartManagmentResults.AddErrorMessages(UserErrors.EmailAlreadyExists);
        }

        if (DepartManagmentResults.ErrorMessages.Count > 0)
            return DepartManagmentResults;
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            DepartManagmentResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
            return DepartManagmentResults;
        }

        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        try
        {
            await _emailSender.SendConfirmationAsync(request.Email, request.ConfirmationLink, token);
        }
        catch
        {
            DepartManagmentResults.AddErrorMessages("Couldn't send confirmation email, try to confirm your email later");
        }
        var userReadModel = user.Adapt<CollageUserViewModel>();
        DepartManagmentResults.IsSuccess = true;

        return DepartManagmentResults;
    }
}
