using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class SiteTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var s = new Site { Name = "S1", Address = "A1" };
            Assert.Equal("S1", s.Name);
        } 
    } 
}
