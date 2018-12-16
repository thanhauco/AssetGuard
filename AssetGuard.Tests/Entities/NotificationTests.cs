using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class NotificationTests 
    { 
        [Fact] 
        public void Entity_InitialState_Unread() 
        { 
            var notif = new Notification { Subject = "Alert" };
            Assert.False(notif.IsRead);
            Assert.Null(notif.ReadAt);
        } 
    } 
}
