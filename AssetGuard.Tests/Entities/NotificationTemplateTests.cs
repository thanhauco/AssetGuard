using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class NotificationTemplateTests 
    { 
        [Fact] 
        public void Entity_SetsBody() 
        { 
            var t = new NotificationTemplate { BodyTemplate = "Hello" };
            Assert.Equal("Hello", t.BodyTemplate);
        } 
    } 
}
