using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ApprovalLogTests
    {
        [Fact]
        public void ApprovalLog_Properties_Work()
        {
            var entity = new ApprovalLog { Action = "Test" };
            Assert.Equal("Test", entity.Action);
        }
    }
}
