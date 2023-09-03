using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace Collage.Entry.Options;
public class CorsPolicyOptionsSetup : IConfigureOptions<CorsOptions>
{
    public void Configure(CorsOptions options)
    {
        options.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
    }
}
