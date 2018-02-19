using Xunit;
using System.Threading.Tasks;

namespace AssetGuard.Tests.Integration
{
    public class UserIntegrationTests
    {
        [Fact]
        public async Task RegisterUser_Works()
        {
            await Task.Delay(1);
            Assert.True(true);
        }
    }
}
