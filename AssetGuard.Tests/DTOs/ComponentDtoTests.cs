using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class ComponentDtoTests
    {
        [Fact]
        public void ComponentDto_Properties_Work()
        {
            var dto = new ComponentDto { Name = "Test" };
            Assert.Equal("Test", dto.Name);
        }
    }
}
