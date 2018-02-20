using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class SiteDtoTests
    {
        [Fact]
        public void SiteDto_Properties_Work()
        {
            var dto = new SiteDto { Name = "Test" };
            Assert.Equal("Test", dto.Name);
        }
    }
}
