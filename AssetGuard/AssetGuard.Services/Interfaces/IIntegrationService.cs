using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IIntegrationService
    {
        Task<IntegrationConfig> CreateIntegrationAsync(IntegrationConfig config);
        Task<IntegrationConfig> GetIntegrationByIdAsync(int id);
        Task<IEnumerable<IntegrationConfig>> GetAllIntegrationsAsync();
        Task EnableIntegrationAsync(int id);
        Task DisableIntegrationAsync(int id);
        
        Task<WebhookSubscription> CreateWebhookAsync(WebhookSubscription subscription);
        Task<IEnumerable<WebhookSubscription>> GetActiveWebhooksAsync();
        Task TriggerWebhookAsync(string eventType, object payload);
        
        Task<SyncJob> StartSyncJobAsync(int integrationId);
        Task<SyncJob> GetSyncJobStatusAsync(int jobId);
        Task<IEnumerable<SyncJob>> GetRecentSyncJobsAsync(int integrationId);
    }
}
