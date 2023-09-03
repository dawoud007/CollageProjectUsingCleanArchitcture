using Collage.Application.Interfaces;
using Collage.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Collage.Infrastructure.NetworkCalls.EmailSender;
public class ResetPasswordEmailSender : BaseEmailSender, IResetPasswordEmailSender
{
    public ResetPasswordEmailSender(IOptions<Smtp> smtp, IConfiguration configuration) : base(smtp, configuration)
    {
    }
}
