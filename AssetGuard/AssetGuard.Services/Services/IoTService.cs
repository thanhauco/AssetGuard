using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class IoTService : IIoTService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IoTService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IoTGateway> RegisterGatewayAsync(IoTGateway gateway)
        {
            await _unitOfWork.Repository<IoTGateway>().AddAsync(gateway);
            await _unitOfWork.CompleteAsync();
            return gateway;
        }

        public async Task<IoTSensor> RegisterSensorAsync(IoTSensor sensor)
        {
            await _unitOfWork.Repository<IoTSensor>().AddAsync(sensor);
            await _unitOfWork.CompleteAsync();
            return sensor;
        }

        public async Task ProcessReadingAsync(string sensorId, double value, DateTime timestamp)
        {
            var allSensors = await _unitOfWork.Repository<IoTSensor>().GetAllAsync();
            var sensor = allSensors.FirstOrDefault(s => s.SensorId == sensorId);
            
            if (sensor != null)
            {
                var reading = new SensorReading
                {
                    SensorId = sensor.Id,
                    Value = value,
                    Timestamp = timestamp,
                    Quality = "Good"
                };
                
                sensor.LastReadingAt = timestamp;
                sensor.LastReadingValue = value;
                
                await _unitOfWork.Repository<SensorReading>().AddAsync(reading);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<SensorReading>> GetReadingsAsync(int sensorId, int limit)
        {
            var all = await _unitOfWork.Repository<SensorReading>().GetAllAsync();
            return all.Where(r => r.SensorId == sensorId)
                      .OrderByDescending(r => r.Timestamp)
                      .Take(limit);
        }

        public async Task<IEnumerable<AnomalyDetectionLog>> DetectAnomaliesAsync(int assetId)
        {
            // Simulation of anomaly detection logic
            var all = await _unitOfWork.Repository<AnomalyDetectionLog>().GetAllAsync();
            return all.Where(a => a.AssetId == assetId);
        }

        public async Task VerifyAnomalyAsync(int anomalyId, bool isFalsePositive, int verifiedById)
        {
            var anomaly = await _unitOfWork.Repository<AnomalyDetectionLog>().GetByIdAsync(anomalyId);
            if (anomaly != null)
            {
                anomaly.IsFalsePositive = isFalsePositive;
                anomaly.VerifiedById = verifiedById;
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<IoTGateway>> GetOfflineGatewaysAsync()
        {
            var all = await _unitOfWork.Repository<IoTGateway>().GetAllAsync();
            return all.Where(g => !g.IsOnline);
        }
    }
}
