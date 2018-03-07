using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class BuildingTests
    {
        [Fact]
        public void Building_Properties_Work()
        {
            var entity = new Building { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
