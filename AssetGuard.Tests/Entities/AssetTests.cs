using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class AssetTests
    {
        [Fact]
        public void Asset_Properties_Work()
        {
            var entity = new Asset { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
