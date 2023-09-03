using Microsoft.AspNetCore.Identity;

namespace Collage.Application.Interfaces;
public interface ITokenGenerator
{
    string Generate(IdentityUser user);
}