using Xunit;
using Moq;
using AssetGuard.Services.Depreciation;

namespace AssetGuard.Tests.Services
{
    public class DepreciationCalculatorTests
    {
        [Fact]
        public void StraightLine_CalculatesCorrectly()
        {
            var strategy = new StraightLineStrategy();
            var calc = new DepreciationCalculator(strategy);
            
            // Cost 1000, Life 10, Years 5. Expense 100/yr. Book Value = 1000 - 500 = 500.
            var result = calc.GetCurrentValue(1000, 10, 5);
            Assert.Equal(500, result);
        }
    }
}
