using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class GlobalService : IGlobalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GlobalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Currency> UpdateExchangeRateAsync(string code, decimal rate)
        {
            var all = await _unitOfWork.Repository<Currency>().GetAllAsync();
            var currency = all.FirstOrDefault(c => c.Code == code);
            
            if (currency == null)
            {
                currency = new Currency { Code = code, Name = code, Symbol = "$" };
                await _unitOfWork.Repository<Currency>().AddAsync(currency);
            }
            
            currency.ExchangeRateToBase = rate;
            currency.RateUpdatedAt = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
            return currency;
        }

        public async Task<decimal> ConvertCurrencyAsync(decimal amount, string fromCode, string toCode)
        {
            var all = await _unitOfWork.Repository<Currency>().GetAllAsync();
            var from = all.FirstOrDefault(c => c.Code == fromCode);
            var to = all.FirstOrDefault(c => c.Code == toCode);

            if (from == null || to == null) return amount;

            // Convert to base, then to target
            var baseAmount = amount / from.ExchangeRateToBase;
            return baseAmount * to.ExchangeRateToBase;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _unitOfWork.Repository<Region>().AddAsync(region);
            await _unitOfWork.CompleteAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _unitOfWork.Repository<Region>().GetAllAsync();
        }

        public async Task<TaxRule> CreateTaxRuleAsync(TaxRule rule)
        {
            await _unitOfWork.Repository<TaxRule>().AddAsync(rule);
            await _unitOfWork.CompleteAsync();
            return rule;
        }

        public async Task<decimal> CalculateTaxAsync(decimal amount, int regionId, int? assetCategoryId)
        {
            var allRules = await _unitOfWork.Repository<TaxRule>().GetAllAsync();
            var rules = allRules.Where(r => r.Jurisdiction.RegionId == regionId && 
                                           (r.AssetCategoryId == assetCategoryId || r.AssetCategoryId == null));
            
            decimal totalTax = 0;
            foreach (var rule in rules)
            {
                totalTax += amount * (rule.RatePercentage / 100m);
            }
            return totalTax;
        }
    }
}
