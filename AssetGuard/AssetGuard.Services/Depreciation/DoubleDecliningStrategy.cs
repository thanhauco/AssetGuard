using System;

namespace AssetGuard.Services.Depreciation
{
    public class DoubleDecliningStrategy : IDepreciationStrategy
    {
        public decimal CalculateBookValue(decimal purchasePrice, int usefulLifeYears, int yearsInService)
        {
            if (yearsInService >= usefulLifeYears) return 0;
            
            decimal currentBookValue = purchasePrice;
            decimal rate = 2.0m / usefulLifeYears;

            for (int i = 0; i < yearsInService; i++)
            {
                currentBookValue -= (currentBookValue * rate);
            }

            return Math.Max(0, currentBookValue);
        }
    }
}
