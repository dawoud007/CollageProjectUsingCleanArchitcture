using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Collage.Entry.Options;
public class IdentityOptionsSetup : IConfigureOptions<IdentityOptions>
{
    public void Configure(IdentityOptions options)
    {
        options.Password.RequireNonAlphanumeric = false;

        options.SignIn.RequireConfirmedEmail = true;
    }
}
