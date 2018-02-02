namespace AssetGuard.Services.Depreciation
{
    public interface IDepreciationStrategy
    {
        decimal CalculateBookValue(decimal purchasePrice, int usefulLifeYears, int yearsInService);
    }
}
