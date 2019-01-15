using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class AuditSessionTests
    {
        [Fact]
        public void Entity_DefaultStatus_IsScheduled()
        {
            var session = new AuditSession();
            Assert.Equal(AuditSessionStatus.Scheduled, session.Status);
        }

        [Fact]
        public void Entity_InitializesCollections()
        {
            var session = new AuditSession();
            Assert.NotNull(session.Scans);
            Assert.NotNull(session.Discrepancies);
        }
    }
}
