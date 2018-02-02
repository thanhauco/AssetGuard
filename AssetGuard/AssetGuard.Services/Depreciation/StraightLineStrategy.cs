using System;

namespace AssetGuard.Services.Depreciation
{
    public class StraightLineStrategy : IDepreciationStrategy
    {
        public decimal CalculateBookValue(decimal purchasePrice, int usefulLifeYears, int yearsInService)
        {
            if (yearsInService >= usefulLifeYears) return 0;
            var expense = purchasePrice / usefulLifeYears;
            return Math.Max(0, purchasePrice - (expense * yearsInService));
        }
    }
}
