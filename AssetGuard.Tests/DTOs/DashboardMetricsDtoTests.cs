using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class DashboardMetricsDtoTests
    {
        [Fact]
        public void DashboardMetricsDto_Properties_Work()
        {
            var dto = new DashboardMetricsDto { TotalAssets = 1 };
            Assert.Equal(1, dto.TotalAssets);
        }
    }
}
