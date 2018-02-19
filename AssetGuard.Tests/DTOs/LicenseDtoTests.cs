using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class LicenseDtoTests
    {
        [Fact]
        public void LicenseDto_Properties_Work()
        {
            var dto = new LicenseDto { SoftwareName = "Test" };
            Assert.Equal("Test", dto.SoftwareName);
        }
    }
}
