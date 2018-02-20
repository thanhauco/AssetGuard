using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class CreateIssueDtoTests
    {
        [Fact]
        public void CreateIssueDto_Properties_Work()
        {
            var dto = new CreateIssueDto { Title = "Test" };
            Assert.Equal("Test", dto.Title);
        }
    }
}
