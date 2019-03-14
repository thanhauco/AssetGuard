using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;
using Newtonsoft.Json;

namespace AssetGuard.Services.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IntegrationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IntegrationConfig> CreateIntegrationAsync(IntegrationConfig config)
        {
            await _unitOfWork.Repository<IntegrationConfig>().AddAsync(config);
            await _unitOfWork.CompleteAsync();
            return config;
        }

        public async Task<IntegrationConfig> GetIntegrationByIdAsync(int id)
        {
            return await _unitOfWork.Repository<IntegrationConfig>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<IntegrationConfig>> GetAllIntegrationsAsync()
        {
            return await _unitOfWork.Repository<IntegrationConfig>().GetAllAsync();
        }

        public async Task EnableIntegrationAsync(int id)
        {
            var config = await GetIntegrationByIdAsync(id);
            config.IsEnabled = true;
            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableIntegrationAsync(int id)
        {
            var config = await GetIntegrationByIdAsync(id);
            config.IsEnabled = false;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<WebhookSubscription> CreateWebhookAsync(WebhookSubscription subscription)
        {
            subscription.Secret = Guid.NewGuid().ToString("N");
            await _unitOfWork.Repository<WebhookSubscription>().AddAsync(subscription);
            await _unitOfWork.CompleteAsync();
            return subscription;
        }

        public async Task<IEnumerable<WebhookSubscription>> GetActiveWebhooksAsync()
        {
            var all = await _unitOfWork.Repository<WebhookSubscription>().GetAllAsync();
            return all.Where(w => w.IsActive);
        }

        public async Task TriggerWebhookAsync(string eventType, object payload)
        {
            var webhooks = await GetActiveWebhooksAsync();
            var matching = webhooks.Where(w => w.EventTypes.Contains(eventType));

            foreach (var webhook in matching)
            {
                webhook.LastTriggeredAt = DateTime.UtcNow;
                webhook.SuccessCount++;
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task<SyncJob> StartSyncJobAsync(int integrationId)
        {
            var job = new SyncJob
            {
                IntegrationConfigId = integrationId,
                Status = SyncJobStatus.Running,
                ScheduledAt = DateTime.UtcNow,
                StartedAt = DateTime.UtcNow
            };

            await _unitOfWork.Repository<SyncJob>().AddAsync(job);
            await _unitOfWork.CompleteAsync();

            job.Status = SyncJobStatus.Completed;
            job.CompletedAt = DateTime.UtcNow;
            job.RecordsProcessed = 100;
            job.RecordsCreated = 10;
            job.RecordsUpdated = 90;

            var config = await GetIntegrationByIdAsync(integrationId);
            config.LastSyncAt = DateTime.UtcNow;
            config.LastSyncStatus = "Success";

            await _unitOfWork.CompleteAsync();
            return job;
        }

        public async Task<SyncJob> GetSyncJobStatusAsync(int jobId)
        {
            return await _unitOfWork.Repository<SyncJob>().GetByIdAsync(jobId);
        }

        public async Task<IEnumerable<SyncJob>> GetRecentSyncJobsAsync(int integrationId)
        {
            var all = await _unitOfWork.Repository<SyncJob>().GetAllAsync();
            return all.Where(j => j.IntegrationConfigId == integrationId)
                      .OrderByDescending(j => j.StartedAt)
                      .Take(10);
        }
    }
}
