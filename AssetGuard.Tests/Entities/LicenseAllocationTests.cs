using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class LicenseAllocationTests 
    { 
        [Fact] 
        public void Entity_SetsInfo() 
        { 
            var l = new LicenseAllocation { AssetId = 1 };
            Assert.Equal(1, l.AssetId);
        } 
    } 
}
