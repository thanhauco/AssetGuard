using System;

namespace AssetGuard.Core.Entities
{
    public enum SensorType
    {
        Temperature,
        Humidity,
        Vibration,
        Pressure,
        UsageCount,
        PowerConsumption,
        Gps
    }

    public class IoTGateway : BaseEntity
    {
        public string Name { get; set; }
        public string DeviceId { get; set; } // External ID from IoT Hub
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string FirmwareVersion { get; set; }
        public bool IsOnline { get; set; }
        public DateTime? LastHeartbeat { get; set; }
        public int? RegionId { get; set; }
    }

    public class IoTSensor : BaseEntity
    {
        public string Name { get; set; }
        public string SensorId { get; set; } // External ID
        public int? GatewayId { get; set; }
        public IoTGateway Gateway { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public SensorType Type { get; set; }
        public string Unit { get; set; }
        public int UpdateIntervalSeconds { get; set; } = 300;
        public bool IsActive { get; set; } = true;
        public DateTime? LastReadingAt { get; set; }
        public double? LastReadingValue { get; set; }
    }

    public class SensorReading : BaseEntity
    {
        public int SensorId { get; set; }
        public IoTSensor Sensor { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Quality { get; set; } // Good, Bad, Uncertain
    }

    public class AnomalyDetectionLog : BaseEntity
    {
        public int AssetId { get; set; }
        public int SensorId { get; set; }
        public DateTime DetectedAt { get; set; } = DateTime.UtcNow;
        public double DetectedValue { get; set; }
        public double ExpectedValue { get; set; }
        public double DeviationScore { get; set; }
        public string Algorithm { get; set; } // "Z-Score", "IsolationForest"
        public bool IsFalsePositive { get; set; } = false;
        public int? VerifiedById { get; set; }
    }
}
