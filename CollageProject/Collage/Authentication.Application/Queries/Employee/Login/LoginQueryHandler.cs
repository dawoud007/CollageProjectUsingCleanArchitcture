using Collage.Application.CommandInterfaces;
using Collage.Application.Interfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Collage.Application.Queries.Login;
public class LoginQueryHandler : IHandler<LoginQuery, ErrorOr<Results>>
{
    private readonly UserManager<CollageUser> _userManager;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginQueryHandler(UserManager<CollageUser> userManager, ITokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ErrorOr<Results>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var DepartManagmentResults = new Results();
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
        {
            DepartManagmentResults.AddErrorMessages("username doesn't exist, Please register");
            return DepartManagmentResults;
        }
        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            DepartManagmentResults.AddErrorMessages("Incorrect password");
            return DepartManagmentResults;
        }

        // if (!user.EmailConfirmed)
        // {
        //     DepartManagmentResults.AddErrorMessages("you email is not confirmed please confirm it first");
        // return DepartManagmentResults;
        // }
        var token = _tokenGenerator.Generate(user);
        DepartManagmentResults.SetToken(token);
        DepartManagmentResults.IsSuccess = true;
        DepartManagmentResults.User = user.Adapt<CollageUserViewModel>();
        return DepartManagmentResults;
    }
}
