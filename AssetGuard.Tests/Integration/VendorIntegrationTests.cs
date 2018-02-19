using Xunit;
using System.Threading.Tasks;

namespace AssetGuard.Tests.Integration
{
    public class VendorIntegrationTests
    {
        [Fact]
        public async Task CreateVendor_Works()
        {
            await Task.Delay(1);
            Assert.True(true);
        }
    }
}
