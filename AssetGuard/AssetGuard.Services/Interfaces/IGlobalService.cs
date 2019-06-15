using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IGlobalService
    {
        Task<Currency> UpdateExchangeRateAsync(string code, decimal rate);
        Task<decimal> ConvertCurrencyAsync(decimal amount, string fromCode, string toCode);
        
        Task<Region> CreateRegionAsync(Region region);
        Task<IEnumerable<Region>> GetAllRegionsAsync();
        
        Task<TaxRule> CreateTaxRuleAsync(TaxRule rule);
        Task<decimal> CalculateTaxAsync(decimal amount, int regionId, int? assetCategoryId);
    }
}
