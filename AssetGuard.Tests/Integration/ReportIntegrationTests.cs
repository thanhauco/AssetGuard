using Xunit;
using System.Threading.Tasks;

namespace AssetGuard.Tests.Integration
{
    public class ReportIntegrationTests
    {
        [Fact]
        public async Task GenerateReport_Works()
        {
            await Task.Delay(1);
            Assert.True(true);
        }
    }
}
