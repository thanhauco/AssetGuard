using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class AssetDtoTests
    {
        [Fact]
        public void AssetDto_Properties_Work()
        {
            var dto = new AssetDto { Name = "Test" };
            Assert.Equal("Test", dto.Name);
        }
    }
}
