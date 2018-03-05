using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class DashboardWidgetTests
    {
        [Fact]
        public void DashboardWidget_Properties_Work()
        {
            var entity = new DashboardWidget { Title = "Test" };
            Assert.Equal("Test", entity.Title);
        }
    }
}
