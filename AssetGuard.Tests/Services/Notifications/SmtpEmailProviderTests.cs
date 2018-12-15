using Xunit;
using System.Threading.Tasks;
using AssetGuard.Services.Services;
using Moq;

namespace AssetGuard.Tests.Services.Notifications 
{ 
    public class SmtpEmailProviderTests 
    { 
        [Fact] 
        public async Task SendEmail_DoesNotThrow() 
        { 
            var provider = new SmtpEmailProvider();
            var ex = await Record.ExceptionAsync(() => provider.SendEmailAsync("to@test.com", "Subj", "Body"));
            Assert.Null(ex);
        } 
    } 
}
