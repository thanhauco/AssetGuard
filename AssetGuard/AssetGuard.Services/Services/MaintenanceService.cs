using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaintenanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MaintenanceRecordDto>> GetMaintenanceHistoryAsync(int assetId)
        {
            var records = await _unitOfWork.Repository<MaintenanceRecord>()
                .FindAsync(m => m.AssetId == assetId);
            
            // Note: In a real scenario we might need to Include(m => m.Asset) to get the name, 
            // strictly depending on how lazy loading is configured or if we fetch the asset separately.
            // keeping it simple for now.
            
            return records.Select(m => new MaintenanceRecordDto
            {
                Id = m.Id,
                AssetId = m.AssetId,
                MaintenanceDate = m.MaintenanceDate,
                Description = m.Description,
                Cost = m.Cost,
                ServiceProvider = m.ServiceProvider
            });
        }

        public async Task<MaintenanceRecordDto> AddMaintenanceRecordAsync(CreateMaintenanceRecordDto maintenanceDto)
        {
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(maintenanceDto.AssetId);
            if (asset == null)
            {
                throw new ArgumentException($"Asset with ID {maintenanceDto.AssetId} not found.");
            }

            var record = new MaintenanceRecord
            {
                AssetId = maintenanceDto.AssetId,
                MaintenanceDate = maintenanceDto.MaintenanceDate,
                Description = maintenanceDto.Description,
                Cost = maintenanceDto.Cost,
                ServiceProvider = maintenanceDto.ServiceProvider
            };

            await _unitOfWork.Repository<MaintenanceRecord>().AddAsync(record);
            await _unitOfWork.CompleteAsync();

            return new MaintenanceRecordDto
            {
                Id = record.Id,
                AssetId = record.AssetId,
                AssetName = asset.Name,
                MaintenanceDate = record.MaintenanceDate,
                Description = record.Description,
                Cost = record.Cost,
                ServiceProvider = record.ServiceProvider
            };
        }
    }
}
