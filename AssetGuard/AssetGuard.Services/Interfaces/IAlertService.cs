using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IAlertService
    {
        Task<AlertRule> CreateRuleAsync(AlertRule rule);
        Task<IEnumerable<AlertRule>> GetActiveRulesAsync();
        Task EnableRuleAsync(int ruleId);
        Task DisableRuleAsync(int ruleId);
        
        Task<Alert> TriggerAlertAsync(int ruleId, int? assetId, string title, string message);
        Task<IEnumerable<Alert>> GetUnreadAlertsAsync();
        Task<IEnumerable<Alert>> GetAlertsForAssetAsync(int assetId);
        Task MarkAsReadAsync(int alertId);
        Task DismissAlertAsync(int alertId, int dismissedById);
        
        Task ProcessScheduledAlertsAsync();
    }
}
