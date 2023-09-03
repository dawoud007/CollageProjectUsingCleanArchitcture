using Collage.Application.CommandInterfaces;
using Collage.Application.Interfaces;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace Collage.Application.Queries.GetUserByUsername;
public class GetUserByUsernameQueryHandler : IHandler<GetUserByUsername, ErrorOr<CollageUserViewModel>>
{
    private readonly UserManager<CollageUser> _userManager;
    private readonly ICollageUserRepository _employeeRepository;

    public GetUserByUsernameQueryHandler(UserManager<CollageUser> userManager, ICollageUserRepository employeeRepository)
    {
        _userManager = userManager;
        _employeeRepository = employeeRepository;
    }

    public async Task<ErrorOr<CollageUserViewModel>> Handle(GetUserByUsername request, CancellationToken cancellationToken)
    {
        string DepartmentValue = "Leqaa";
        var user = await _userManager.FindByNameAsync(request.UserName);
        var CollageUser = (await _employeeRepository.Get(e => e.UserName == request.UserName, null, "Tasks,Department")).FirstOrDefault()!;


        var result = new CollageUserViewModel(
       CollageUser.Id,
       CollageUser.Name,
       CollageUser.Email,
       CollageUser.UserName,
       CollageUser.Gender,
       CollageUser.Role,
       DepartmentValue

   );


        return result;
    }
}
