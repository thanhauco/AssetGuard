using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class SoftwareLicenseTests
    {
        [Fact]
        public void SoftwareLicense_Properties_Work()
        {
            var entity = new SoftwareLicense { SoftwareName = "Test" };
            Assert.Equal("Test", entity.SoftwareName);
        }
    }
}
