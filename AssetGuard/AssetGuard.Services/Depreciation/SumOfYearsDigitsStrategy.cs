using System;

namespace AssetGuard.Services.Depreciation
{
    public class SumOfYearsDigitsStrategy : IDepreciationStrategy
    {
        public decimal CalculateBookValue(decimal purchasePrice, int usefulLifeYears, int yearsInService)
        {
            if (yearsInService >= usefulLifeYears) return 0;

            int sumOfYears = usefulLifeYears * (usefulLifeYears + 1) / 2;
            decimal accumulatedDepreciation = 0;

            for (int i = 0; i < yearsInService; i++)
            {
                int yearsRemaining = usefulLifeYears - i;
                decimal fraction = (decimal)yearsRemaining / sumOfYears;
                accumulatedDepreciation += (purchasePrice * fraction);
            }

            return Math.Max(0, purchasePrice - accumulatedDepreciation);
        }
    }
}
