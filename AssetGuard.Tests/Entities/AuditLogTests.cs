using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class AuditLogTests
    {
        [Fact]
        public void AuditLog_Properties_Work()
        {
            var entity = new AuditLog { Action = "Test" };
            Assert.Equal("Test", entity.Action);
        }
    }
}
