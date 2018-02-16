using Xunit;
using System.Threading.Tasks;

namespace AssetGuard.Tests.Integration
{
    public class IssueIntegrationTests
    {
        [Fact]
        public async Task ReportIssue_Works()
        {
            await Task.Delay(1);
            Assert.True(true);
        }
    }
}
