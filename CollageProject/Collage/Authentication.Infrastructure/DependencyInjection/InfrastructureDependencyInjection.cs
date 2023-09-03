using Collage.Application.Interfaces;
using Collage.Infrastructure.Models;
using Collage.Infrastructure.NetworkCalls.EmailSender;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Collage.Infrastructure.DependencyInjection;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Jwt>(configuration.GetSection("Jwt"));
        services.Configure<Smtp>(configuration.GetSection("Smtp"));

        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IConfirmationEmailSender, ConfirmationEmailSender>();
        services.AddSingleton<IResetPasswordEmailSender, ResetPasswordEmailSender>();
        /*      services.AddScoped<ICollag, CollageUserRepository>();*/


        return services;

    }
}