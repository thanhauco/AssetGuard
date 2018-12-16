using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class SoftwareLicenseTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var l = new SoftwareLicense { SoftwareName = "Soft1", Seats = 5 };
            Assert.Equal(5, l.Seats);
        } 
    } 
}
