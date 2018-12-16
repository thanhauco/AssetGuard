using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class AssetComponentTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var c = new AssetComponent { Name = "HDD" };
            Assert.Equal("HDD", c.Name);
        } 
    } 
}
