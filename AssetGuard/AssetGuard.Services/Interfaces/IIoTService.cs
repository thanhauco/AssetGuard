using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IIoTService
    {
        Task<IoTGateway> RegisterGatewayAsync(IoTGateway gateway);
        Task<IoTSensor> RegisterSensorAsync(IoTSensor sensor);
        
        Task ProcessReadingAsync(string sensorId, double value, DateTime timestamp);
        Task<IEnumerable<SensorReading>> GetReadingsAsync(int sensorId, int limit);
        
        Task<IEnumerable<AnomalyDetectionLog>> DetectAnomaliesAsync(int assetId);
        Task VerifyAnomalyAsync(int anomalyId, bool isFalsePositive, int verifiedById);
        
        Task<IEnumerable<IoTGateway>> GetOfflineGatewaysAsync();
    }
}
