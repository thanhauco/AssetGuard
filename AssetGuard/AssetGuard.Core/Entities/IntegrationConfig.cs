using System;

namespace AssetGuard.Core.Entities
{
    public class IntegrationConfig : BaseEntity
    {
        public string Name { get; set; }
        public string IntegrationType { get; set; }  // HR, ERP, Webhook, API
        public string EndpointUrl { get; set; }
        public string AuthType { get; set; }  // None, Basic, Bearer, OAuth
        public string CredentialsJson { get; set; }
        public bool IsEnabled { get; set; } = true;
        public string SyncDirection { get; set; }  // Inbound, Outbound, Bidirectional
        public int SyncIntervalMinutes { get; set; } = 60;
        public DateTime? LastSyncAt { get; set; }
        public string LastSyncStatus { get; set; }
    }
}
