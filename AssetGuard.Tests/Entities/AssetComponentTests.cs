using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class AssetComponentTests
    {
        [Fact]
        public void AssetComponent_Properties_Work()
        {
            var entity = new AssetComponent { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
