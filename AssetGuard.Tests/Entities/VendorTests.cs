using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class VendorTests 
    { 
        [Fact] 
        public void Entity_SetsProperties() 
        { 
            var v = new Vendor { Name = "TechCorp", ContactEmail = "sales@techcorp.com" };
            Assert.Equal("TechCorp", v.Name);
            Assert.Equal(VerificationStatus.Pending, v.Status);
        } 
    } 
}
