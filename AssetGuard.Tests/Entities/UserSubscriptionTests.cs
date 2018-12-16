using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class UserSubscriptionTests 
    { 
        [Fact] 
        public void Entity_SetsEvent() 
        { 
            var s = new UserSubscription { EventKey = "E1" };
            Assert.Equal("E1", s.EventKey);
        } 
    } 
}
