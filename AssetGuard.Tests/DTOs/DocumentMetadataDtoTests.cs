using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class DocumentMetadataDtoTests
    {
        [Fact]
        public void DocumentMetadataDto_Properties_Work()
        {
            var dto = new DocumentMetadataDto { Title = "Test" };
            Assert.Equal("Test", dto.Title);
        }
    }
}
