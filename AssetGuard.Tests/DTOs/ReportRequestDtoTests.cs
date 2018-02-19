using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class ReportRequestDtoTests
    {
        [Fact]
        public void ReportRequestDto_Properties_Work()
        {
            var dto = new ReportRequestDto { Format = "Test" };
            Assert.Equal("Test", dto.Format);
        }
    }
}
