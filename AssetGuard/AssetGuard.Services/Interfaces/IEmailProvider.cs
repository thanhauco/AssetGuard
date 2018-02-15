using System.Threading.Tasks;

namespace AssetGuard.Services.Interfaces
{
    public interface IEmailProvider
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
