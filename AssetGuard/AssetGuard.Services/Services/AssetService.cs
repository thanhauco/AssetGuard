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
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AssetDto>> GetAllAssetsAsync()
        {
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            // In a real app, use AutoMapper. Here we map manually.
            return assets.Select(a => MapToDto(a));
        }

        public async Task<AssetDto> GetAssetByIdAsync(int id)
        {
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(id);
            return asset == null ? null : MapToDto(asset);
        }

        public async Task<AssetDto> CreateAssetAsync(CreateAssetDto assetDto)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(assetDto.CategoryId);
            if (category == null) throw new ArgumentException("Invalid Category ID");

            var asset = new Asset
            {
                Name = assetDto.Name,
                SerialNumber = assetDto.SerialNumber,
                Description = assetDto.Description,
                PurchaseDate = assetDto.PurchaseDate,
                PurchasePrice = assetDto.PurchasePrice,
                CategoryId = assetDto.CategoryId,
                Assignments = new List<Assignment>(),
                MaintenanceRecords = new List<MaintenanceRecord>()
            };

            await _unitOfWork.Repository<Asset>().AddAsync(asset);
            await _unitOfWork.CompleteAsync();

            return MapToDto(asset);
        }

        public async Task AssignAssetAsync(int assetId, int employeeId)
        {
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(assetId);
            if (asset == null) throw new ArgumentException("Asset not found");

            var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(employeeId);
            if (employee == null) throw new ArgumentException("Employee not found");

            var assignment = new Assignment
            {
                AssetId = assetId,
                EmployeeId = employeeId,
                AssignedDate = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Assignment>().AddAsync(assignment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task ReturnAssetAsync(int assetId)
        {
            // Simplified logic: find active assignment and close it
             var assignments = await _unitOfWork.Repository<Assignment>().FindAsync(a => a.AssetId == assetId && a.ReturnDate == null);
             var activeAssignment = assignments.FirstOrDefault();

             if (activeAssignment != null)
             {
                 activeAssignment.ReturnDate = DateTime.UtcNow;
                 await _unitOfWork.Repository<Assignment>().UpdateAsync(activeAssignment);
                 await _unitOfWork.CompleteAsync();
             }
        }

        private AssetDto MapToDto(Asset asset)
        {
            if (asset == null) return null;
            return new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                SerialNumber = asset.SerialNumber,
                PurchasePrice = asset.PurchasePrice,
                CategoryName = asset.Category?.Name ?? "Unknown", 
                Status = "Available" // Simplified
            };
        }
    }
}
