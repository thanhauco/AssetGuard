using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class AlertService : IAlertService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlertService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AlertRule> CreateRuleAsync(AlertRule rule)
        {
            await _unitOfWork.Repository<AlertRule>().AddAsync(rule);
            await _unitOfWork.CompleteAsync();
            return rule;
        }

        public async Task<IEnumerable<AlertRule>> GetActiveRulesAsync()
        {
            var all = await _unitOfWork.Repository<AlertRule>().GetAllAsync();
            return all.Where(r => r.IsActive);
        }

        public async Task EnableRuleAsync(int ruleId)
        {
            var rule = await _unitOfWork.Repository<AlertRule>().GetByIdAsync(ruleId);
            rule.IsActive = true;
            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableRuleAsync(int ruleId)
        {
            var rule = await _unitOfWork.Repository<AlertRule>().GetByIdAsync(ruleId);
            rule.IsActive = false;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Alert> TriggerAlertAsync(int ruleId, int? assetId, string title, string message)
        {
            var rule = await _unitOfWork.Repository<AlertRule>().GetByIdAsync(ruleId);
            
            var alert = new Alert
            {
                AlertRuleId = ruleId,
                AssetId = assetId,
                Severity = rule.Severity,
                Title = title,
                Message = message
            };

            await _unitOfWork.Repository<Alert>().AddAsync(alert);
            await _unitOfWork.CompleteAsync();
            return alert;
        }

        public async Task<IEnumerable<Alert>> GetUnreadAlertsAsync()
        {
            var all = await _unitOfWork.Repository<Alert>().GetAllAsync();
            return all.Where(a => !a.IsRead && !a.IsDismissed).OrderByDescending(a => a.TriggeredAt);
        }

        public async Task<IEnumerable<Alert>> GetAlertsForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<Alert>().GetAllAsync();
            return all.Where(a => a.AssetId == assetId).OrderByDescending(a => a.TriggeredAt);
        }

        public async Task MarkAsReadAsync(int alertId)
        {
            var alert = await _unitOfWork.Repository<Alert>().GetByIdAsync(alertId);
            alert.IsRead = true;
            alert.ReadAt = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task DismissAlertAsync(int alertId, int dismissedById)
        {
            var alert = await _unitOfWork.Repository<Alert>().GetByIdAsync(alertId);
            alert.IsDismissed = true;
            alert.DismissedAt = DateTime.UtcNow;
            alert.DismissedById = dismissedById;
            await _unitOfWork.CompleteAsync();
        }

        public async Task ProcessScheduledAlertsAsync()
        {
            var rules = await GetActiveRulesAsync();
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();

            foreach (var rule in rules)
            {
                foreach (var asset in assets)
                {
                    if (rule.CategoryId.HasValue && asset.CategoryId != rule.CategoryId) continue;
                    
                    // Simplified alert processing logic
                    if (rule.Type == AlertType.EndOfLife)
                    {
                        var endOfLife = asset.PurchaseDate.AddYears(5);
                        if (endOfLife <= DateTime.UtcNow.AddDays(rule.TriggerDaysBefore))
                        {
                            await TriggerAlertAsync(rule.Id, asset.Id, 
                                $"End of Life: {asset.Name}", 
                                $"Asset reaches end of life on {endOfLife:d}");
                        }
                    }
                }
            }
        }
    }
}
