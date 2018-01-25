using Xunit;
using AssetGuard.Services.Depreciation;

namespace AssetGuard.Tests.Services.DepreciationStrategyTests
{
    public class DoubleDecliningStrategyTests
    {
        [Fact]
        public void Calculate_ReturnsValidValue()
        {
            var strategy = new DoubleDecliningStrategy();
            var val = strategy.CalculateBookValue(1000, 5, 1);
            // 2/5 = 40%. 1000 - 400 = 600.
            Assert.Equal(600, val);
        }
    }
}
