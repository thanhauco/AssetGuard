using Xunit;
using AssetGuard.Services.Depreciation;

namespace AssetGuard.Tests.Services.DepreciationStrategyTests
{
    public class SumOfYearsDigitsStrategyTests
    {
        [Fact]
        public void Calculate_ReturnsValidValue()
        {
            var strategy = new SumOfYearsDigitsStrategy();
            // 5 years. Sum = 15. Yr 1 fraction = 5/15 = 1/3.
            // 3000 * 1/3 = 1000 dep. Book = 2000.
            var val = strategy.CalculateBookValue(3000, 5, 1);
            Assert.Equal(2000, val); 
        }
    }
}
