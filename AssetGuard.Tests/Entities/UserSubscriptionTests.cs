using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class UserSubscriptionTests
    {
        [Fact]
        public void UserSubscription_Properties_Work()
        {
            var entity = new UserSubscription { EventKey = "Test" };
            Assert.Equal("Test", entity.EventKey);
        }
    }
}
