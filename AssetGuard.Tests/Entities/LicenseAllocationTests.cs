using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class LicenseAllocationTests
    {
        [Fact]
        public void LicenseAllocation_Properties_Work()
        {
            var entity = new LicenseAllocation { AssetId = 1 };
            Assert.Equal(1, entity.AssetId);
        }
    }
}
