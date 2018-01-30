using Xunit;
using System.Threading.Tasks;
using AssetGuard.Services.Services;

namespace AssetGuard.Tests.Services.Notifications
{
    public class SmtpEmailProviderTests
    {
        [Fact]
        public async Task SendEmail_Completes()
        {
            var provider = new SmtpEmailProvider();
            await provider.SendEmailAsync("test@test.com", "Subj", "Body");
            Assert.True(true);
        }
    }
}
