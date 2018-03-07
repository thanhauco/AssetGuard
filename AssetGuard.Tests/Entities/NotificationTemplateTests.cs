using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class NotificationTemplateTests
    {
        [Fact]
        public void NotificationTemplate_Properties_Work()
        {
            var entity = new NotificationTemplate { Key = "Test" };
            Assert.Equal("Test", entity.Key);
        }
    }
}
