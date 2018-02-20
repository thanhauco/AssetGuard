using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class VendorDtoTests
    {
        [Fact]
        public void VendorDto_Properties_Work()
        {
            var dto = new VendorDto { Name = "Test" };
            Assert.Equal("Test", dto.Name);
        }
    }
}
