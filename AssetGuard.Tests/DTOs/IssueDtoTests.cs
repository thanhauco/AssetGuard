using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class IssueDtoTests
    {
        [Fact]
        public void IssueDto_Properties_Work()
        {
            var dto = new IssueDto { Title = "Test" };
            Assert.Equal("Test", dto.Title);
        }
    }
}
