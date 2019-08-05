using System;

namespace AssetGuard.Core.Entities
{
    public class DigitalTwin : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string ModelVersion { get; set; }
        public string CadModelUrl { get; set; }
        public string SimulationConfig { get; set; }
        public DateTime LastSyncedAt { get; set; }
        public string Status { get; set; }
    }

    public class SimulationScenario : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssetId { get; set; }
        public string Parameters { get; set; }
        public string ResultMetrics { get; set; }
        public double StressTestScore { get; set; }
        public DateTime RunAt { get; set; } = DateTime.UtcNow;
    }

    public class TwinSyncLog : BaseEntity
    {
        public int DigitalTwinId { get; set; }
        public DateTime SyncTime { get; set; } = DateTime.UtcNow;
        public string ChangesDetected { get; set; }
        public bool Success { get; set; }
    }
}
