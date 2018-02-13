using System.Threading.Tasks;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class SmtpEmailProvider : IEmailProvider
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            // Simulate SMTP send
            return Task.CompletedTask;
        }
    }
}
