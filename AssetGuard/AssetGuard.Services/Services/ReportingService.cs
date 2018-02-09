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
    public class ReportingService : IReportingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DashboardMetricsDto> GetDashboardMetricsAsync()
        {
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            var issues = await _unitOfWork.Repository<Issue>().FindAsync(i => i.Status == IssueStatus.Open);
            var contracts = await _unitOfWork.Repository<Contract>().FindAsync(c => c.EndDate > DateTime.UtcNow);

            return new DashboardMetricsDto
            {
                TotalAssets = assets.Count,
                TotalValue = assets.Sum(a => a.PurchasePrice),
                PendingIssues = issues.Count(),
                ActiveContracts = contracts.Count()
            };
        }

        public async Task<byte[]> GenerateReportAsync(ReportRequestDto request)
        {
            // Simulate report generation
            // In a real app, this would query data based on DefinitionId and render PDF/CSV
            return new byte[0]; 
        }

        public async Task<IEnumerable<dynamic>> GetReportDefinitionsAsync()
        {
            var defs = await _unitOfWork.Repository<ReportDefinition>().GetAllAsync();
            return defs.Select(d => new { d.Id, d.Name, d.Description });
        }
    }
}
