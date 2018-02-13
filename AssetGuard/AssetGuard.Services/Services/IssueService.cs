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
    public class IssueService : IIssueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IssueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IssueDto> ReportIssueAsync(CreateIssueDto dto)
        {
            var issue = new Issue
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                Status = IssueStatus.Open,
                AssetId = dto.AssetId
            };

            await _unitOfWork.Repository<Issue>().AddAsync(issue);
            await _unitOfWork.CompleteAsync();
            
            // Re-fetch to get Asset name if needed, or simple mapping
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(dto.AssetId);

            return new IssueDto
            {
                Id = issue.Id,
                Title = issue.Title,
                Priority = issue.Priority.ToString(),
                Status = issue.Status.ToString(),
                AssetName = asset != null ? asset.Name : "Unknown",
                CreatedAt = issue.CreatedAt
            };
        }

        public async Task<IEnumerable<IssueDto>> GetOpenIssuesAsync()
        {
            var issues = await _unitOfWork.Repository<Issue>().FindAsync(i => i.Status == IssueStatus.Open);
            // In real app, would use projection/mapper
            return issues.Select(i => new IssueDto
            {
                Id = i.Id,
                Title = i.Title,
                Priority = i.Priority.ToString(),
                Status = i.Status.ToString(),
                AssetName = "Loading...", // Optimized query needed in real implementation
                CreatedAt = i.CreatedAt
            });
        }

        public async Task ResolveIssueAsync(int issueId)
        {
            var issue = await _unitOfWork.Repository<Issue>().GetByIdAsync(issueId);
            if (issue != null)
            {
                issue.Status = IssueStatus.Resolved;
                issue.ResolvedAt = DateTime.UtcNow;
                await _unitOfWork.Repository<Issue>().UpdateAsync(issue);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
