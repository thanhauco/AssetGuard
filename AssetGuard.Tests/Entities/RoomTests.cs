using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class RoomTests
    {
        [Fact]
        public void Room_Properties_Work()
        {
            var entity = new Room { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
