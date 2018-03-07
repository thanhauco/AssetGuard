using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ApprovalRequestTests
    {
        [Fact]
        public void ApprovalRequest_Properties_Work()
        {
            var entity = new ApprovalRequest { Status = "Test" };
            Assert.Equal("Test", entity.Status);
        }
    }
}
