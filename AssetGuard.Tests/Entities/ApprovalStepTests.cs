using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ApprovalStepTests
    {
        [Fact]
        public void ApprovalStep_Properties_Work()
        {
            var entity = new ApprovalStep { ApproverRole = "Test" };
            Assert.Equal("Test", entity.ApproverRole);
        }
    }
}
