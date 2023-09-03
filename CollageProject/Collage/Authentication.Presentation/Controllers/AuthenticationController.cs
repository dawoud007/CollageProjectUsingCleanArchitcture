
using BusinessLogic.Presentation;
using Collage.Application.Commands.CollageUsers.DeleteCollageUser;
using Collage.Application.Commands.CollageUsers.UpdateCollageUser;
using Collage.Application.Commands.ConfirmEmail;
using Collage.Application.Commands.ConfirmResetPasswordToken;
using Collage.Application.Commands.RegisterUser;
using Collage.Application.Interfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Application.Queries.GetUserByUsername;
using Collage.Application.Queries.Login;
using Collage.Application.Queries.SendEmailConfirmation;
using Collage.Application.Queries.SendEmailResetPassword;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Collage.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class DepartManagmentController : BaseController
{
    private readonly ISender _sender;
    private readonly UserManager<CollageUser> _userManager;
    private readonly ICollageUserRepository _employeeRepository;
    public DepartManagmentController(ISender sender, UserManager<CollageUser> userManager, ICollageUserRepository employeeRepository)
    {
        _sender = sender;
        _userManager = userManager;
        _employeeRepository = employeeRepository;
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(CollageUserCreateUpdateModel userWriteModel)
    {

        var registerUserCommand = userWriteModel.Adapt<RegisterUserCommand>();
        registerUserCommand = registerUserCommand with
        {
            ConfirmationLink = Url.Action(nameof(ConfirmEmail))
        };
        ErrorOr<Results> results = await _sender.Send(registerUserCommand);
        return results.Match(
         hub => Ok(hub),
         errors => Problem(errors)
     );
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCredentials credentials)
    {
        var loginQuery = credentials.Adapt<LoginQuery>();
        ErrorOr<Results> results = await _sender.Send(loginQuery);


        return results.Match(
         hub => Ok(hub),
         errors => Problem(errors)
     );
    }
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetCollageUserByName([FromQuery] string Name)
    {




        var getUserByUsernameQuery = new GetUserByUsername(Name);
        var results = await _sender.Send(getUserByUsernameQuery);
        return results.Match(
          hub => Ok(hub),
          errors => Problem(errors)
      );
    }


    [HttpPut("{employeeId}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> UpdateCollageUser(string employeeId, CollageUserCreateUpdateModel employeeUpdateModel)
    {


        var updateCollageUserCommand = new UpdateCollageUserCommand
        (
         employeeId,
       employeeUpdateModel
        );

        ErrorOr<Results> results = await _sender.Send(updateCollageUserCommand);

        return results.Match(
            success => Ok(success),
            errors => Problem(errors)
        );
    }



    [HttpDelete("{employeeId}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> DeleteCollageUser(string employeeId)
    {


        var deleteCollageUserCommand = new DeleteCollageUserCommand
        (
            employeeId
       );

        ErrorOr<Results> results = await _sender.Send(deleteCollageUserCommand);

        return results.Match(
            success => Ok(success),
            errors => Problem(errors)
        );
    }



    [HttpGet]
    [Authorize]
    public IActionResult CheckIfAuthenticated()
    {
        return Ok("You are authenticated");
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SendConfirmationEmail(string email)
    {
        var emailConfirmationQuery = new SendEmailConfirmationQuery(email, Url.Action(nameof(ConfirmEmail)));
        var results = await _sender.Send(emailConfirmationQuery);
        return results.Match(
          hub => Ok(hub),
          errors => Problem(errors)
      );
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SendResetPasswordEmail(string email)
    {
        var emailResetPasswordQuery = new SendEmailResetPasswordQuery(email);
        var results = await _sender.Send(emailResetPasswordQuery);
        return results.Match(
         hub => Ok(hub),
         errors => Problem(errors)
     );
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand confirmEmailRequest)
    {
        ErrorOr<Results> results = await _sender.Send(confirmEmailRequest);
        return results.Match(
          hub => Ok(hub),
          errors => Problem(errors)
      );
    }
    [HttpPut]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(ConfirmResetPasswordTokenCommand resetPasswordRequest)
    {

        var results = await _sender.Send(resetPasswordRequest);
        return results.Match(
          hub => Ok(hub),
          errors => Problem(errors)
      );
    }

}