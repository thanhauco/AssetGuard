using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class SubmitApprovalDtoTests
    {
        [Fact]
        public void SubmitApprovalDto_Properties_Work()
        {
            var dto = new SubmitApprovalDto { WorkflowName = "Test" };
            Assert.Equal("Test", dto.WorkflowName);
        }
    }
}
