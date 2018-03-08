using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class SiteTests
    {
        [Fact]
        public void Site_Properties_Work()
        {
            var entity = new Site { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
