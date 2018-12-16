using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ContractTests 
    { 
        [Fact] 
        public void Entity_SetsTitle() 
        { 
            var c = new Contract { Title = "C1", VendorId = 1 };
            Assert.Equal("C1", c.Title);
        } 
    } 
}
