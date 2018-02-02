using System.Collections.Generic;

namespace AssetGuard.Services.Depreciation
{
    public class DepreciationCalculator
    {
        private readonly IDepreciationStrategy _strategy;

        public DepreciationCalculator(IDepreciationStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal GetCurrentValue(decimal price, int life, int years)
        {
            return _strategy.CalculateBookValue(price, life, years);
        }
    }
}
