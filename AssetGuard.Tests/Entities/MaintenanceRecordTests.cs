using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class MaintenanceRecordTests
    {
        [Fact]
        public void MaintenanceRecord_Properties_Work()
        {
            var entity = new MaintenanceRecord { Description = "Test" };
            Assert.Equal("Test", entity.Description);
        }
    }
}
