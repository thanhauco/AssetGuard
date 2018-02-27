using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class ApprovalActionDtoTests
    {
        [Fact]
        public void ApprovalActionDto_Properties_Work()
        {
            var dto = new ApprovalActionDto { Comments = "Test" };
            Assert.Equal("Test", dto.Comments);
        }
    }
}
