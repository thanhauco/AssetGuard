using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class BuildingTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var b = new Building { Name = "B1", SiteId = 1 };
            Assert.Equal("B1", b.Name);
            Assert.Equal(1, b.SiteId);
        } 
    } 
}
