using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class NotificationTests
    {
        [Fact]
        public void Notification_Properties_Work()
        {
            var entity = new Notification { Subject = "Test" };
            Assert.Equal("Test", entity.Subject);
        }
    }
}
