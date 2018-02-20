using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class DocumentUploadDtoTests
    {
        [Fact]
        public void DocumentUploadDto_Properties_Work()
        {
            var dto = new DocumentUploadDto { Title = "Test" };
            Assert.Equal("Test", dto.Title);
        }
    }
}
