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
    public class InventoryAuditService : IInventoryAuditService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryAuditService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuditSession> CreateSessionAsync(CreateAuditSessionDto dto)
        {
            var session = new AuditSession
            {
                Name = dto.Name,
                SiteId = dto.SiteId,
                BuildingId = dto.BuildingId,
                ScheduledDate = dto.ScheduledDate,
                ConductedById = dto.ConductedById,
                Notes = dto.Notes,
                Status = AuditSessionStatus.Scheduled
            };

            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            session.TotalAssetsExpected = assets.Count();

            await _unitOfWork.Repository<AuditSession>().AddAsync(session);
            await _unitOfWork.CompleteAsync();
            return session;
        }

        public async Task<AuditSession> GetSessionByIdAsync(int id)
        {
            return await _unitOfWork.Repository<AuditSession>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<AuditSession>> GetActiveSessionsAsync()
        {
            var all = await _unitOfWork.Repository<AuditSession>().GetAllAsync();
            return all.Where(s => s.Status == AuditSessionStatus.InProgress || s.Status == AuditSessionStatus.Scheduled);
        }

        public async Task StartSessionAsync(int sessionId)
        {
            var session = await GetSessionByIdAsync(sessionId);
            session.Status = AuditSessionStatus.InProgress;
            session.StartedAt = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task CompleteSessionAsync(int sessionId)
        {
            var session = await GetSessionByIdAsync(sessionId);
            session.Status = AuditSessionStatus.Completed;
            session.CompletedAt = DateTime.UtcNow;
            await GenerateDiscrepanciesAsync(sessionId);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<AuditScan> RecordScanAsync(RecordScanDto dto)
        {
            var scan = new AuditScan
            {
                AuditSessionId = dto.AuditSessionId,
                AssetId = dto.AssetId,
                ScannedById = dto.ScannedById,
                FoundInRoomId = dto.FoundInRoomId,
                Condition = dto.Condition,
                Notes = dto.Notes,
                ScannedAt = DateTime.UtcNow
            };

            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(dto.AssetId);
            scan.LocationMismatch = asset.RoomId != dto.FoundInRoomId;

            await _unitOfWork.Repository<AuditScan>().AddAsync(scan);

            var session = await GetSessionByIdAsync(dto.AuditSessionId);
            session.TotalAssetsScanned++;
            
            await _unitOfWork.CompleteAsync();
            return scan;
        }

        public async Task<IEnumerable<AuditScan>> GetScansForSessionAsync(int sessionId)
        {
            var all = await _unitOfWork.Repository<AuditScan>().GetAllAsync();
            return all.Where(s => s.AuditSessionId == sessionId);
        }

        public async Task<IEnumerable<DiscrepancyReport>> GenerateDiscrepanciesAsync(int sessionId)
        {
            var session = await GetSessionByIdAsync(sessionId);
            var scans = await GetScansForSessionAsync(sessionId);
            var scannedAssetIds = scans.Select(s => s.AssetId).ToHashSet();
            var allAssets = await _unitOfWork.Repository<Asset>().GetAllAsync();

            var discrepancies = new List<DiscrepancyReport>();

            foreach (var asset in allAssets)
            {
                if (!scannedAssetIds.Contains(asset.Id))
                {
                    var disc = new DiscrepancyReport
                    {
                        AuditSessionId = sessionId,
                        AssetId = asset.Id,
                        Type = DiscrepancyType.Missing,
                        Description = $"Asset '{asset.Name}' was not scanned during audit"
                    };
                    discrepancies.Add(disc);
                    await _unitOfWork.Repository<DiscrepancyReport>().AddAsync(disc);
                }
            }

            foreach (var scan in scans.Where(s => s.LocationMismatch))
            {
                var disc = new DiscrepancyReport
                {
                    AuditSessionId = sessionId,
                    AssetId = scan.AssetId,
                    Type = DiscrepancyType.LocationMismatch,
                    Description = "Asset found in different location than expected",
                    ActualLocation = scan.FoundInRoomId?.ToString()
                };
                discrepancies.Add(disc);
                await _unitOfWork.Repository<DiscrepancyReport>().AddAsync(disc);
            }

            await _unitOfWork.CompleteAsync();
            return discrepancies;
        }

        public async Task ResolveDiscrepancyAsync(ResolveDiscrepancyDto dto)
        {
            var disc = await _unitOfWork.Repository<DiscrepancyReport>().GetByIdAsync(dto.DiscrepancyId);
            disc.Resolution = Enum.Parse<DiscrepancyResolution>(dto.Resolution);
            disc.ResolutionNotes = dto.ResolutionNotes;
            disc.ResolvedById = dto.ResolvedById;
            disc.ResolvedAt = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<AuditSummaryDto> GetAuditSummaryAsync(int sessionId)
        {
            var session = await GetSessionByIdAsync(sessionId);
            var discrepancies = await _unitOfWork.Repository<DiscrepancyReport>().GetAllAsync();
            var sessionDisc = discrepancies.Where(d => d.AuditSessionId == sessionId);

            return new AuditSummaryDto
            {
                SessionId = sessionId,
                SessionName = session.Name,
                TotalExpected = session.TotalAssetsExpected,
                TotalScanned = session.TotalAssetsScanned,
                TotalMissing = sessionDisc.Count(d => d.Type == DiscrepancyType.Missing),
                TotalDiscrepancies = sessionDisc.Count(),
                CompletionPercentage = session.TotalAssetsExpected > 0
                    ? (decimal)session.TotalAssetsScanned / session.TotalAssetsExpected * 100
                    : 0
            };
        }
    }
}
