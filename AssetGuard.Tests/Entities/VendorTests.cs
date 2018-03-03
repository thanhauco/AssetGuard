using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class VendorTests
    {
        [Fact]
        public void Vendor_Properties_Work()
        {
            var entity = new Vendor { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
