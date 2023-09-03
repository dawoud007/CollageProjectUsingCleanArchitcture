using Collage.Application.CommandInterfaces;
using Collage.Application.Commands.ConfirmResetPasswordToken;
using Collage.Application.Models.CollageUsers;
using Collage.Domain.Entities.ApplicationUser;
using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace Collage.Application.Commands.ResetPassword
{
    public class ConfirmResetPasswordTokenCommandHandler : IHandler<ConfirmResetPasswordTokenCommand, ErrorOr<string>>
    {
        private readonly UserManager<CollageUser> _userManager;
        private readonly SignInManager<CollageUser> _signInManager;

        public ConfirmResetPasswordTokenCommandHandler(UserManager<CollageUser> userManager, SignInManager<CollageUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ErrorOr<string>> Handle(ConfirmResetPasswordTokenCommand request, CancellationToken cancellationToken)
        {
            var result = new Results();

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {

                return "Email does not exist";
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.CurrentPassword, false);
            if (!signInResult.Succeeded)
            {

                return "Invalid current password";

            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetResult = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
            if (!resetResult.Succeeded)
            {

                return "operation please check your inputs";
            }

            result.IsSuccess = true;
            return "password was reset sucessfully";
        }
    }
}