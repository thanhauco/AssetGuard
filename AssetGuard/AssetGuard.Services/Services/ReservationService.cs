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
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssetReservation> CreateReservationAsync(CreateReservationDto dto)
        {
            var isAvailable = await IsAssetAvailableAsync(dto.AssetId, dto.StartDate, dto.EndDate);
            if (!isAvailable)
                throw new InvalidOperationException("Asset is not available for the requested period");

            var reservation = new AssetReservation
            {
                AssetId = dto.AssetId,
                RequestedById = dto.RequestedById,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Purpose = dto.Purpose,
                Notes = dto.Notes,
                Status = ReservationStatus.Pending
            };

            await _unitOfWork.Repository<AssetReservation>().AddAsync(reservation);
            await _unitOfWork.CompleteAsync();
            return reservation;
        }

        public async Task<AssetReservation> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<AssetReservation>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<AssetReservation>> GetReservationsForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<AssetReservation>().GetAllAsync();
            return all.Where(r => r.AssetId == assetId);
        }

        public async Task<IEnumerable<AssetReservation>> GetPendingReservationsAsync()
        {
            var all = await _unitOfWork.Repository<AssetReservation>().GetAllAsync();
            return all.Where(r => r.Status == ReservationStatus.Pending);
        }

        public async Task<IEnumerable<AssetReservation>> GetUserReservationsAsync(int userId)
        {
            var all = await _unitOfWork.Repository<AssetReservation>().GetAllAsync();
            return all.Where(r => r.RequestedById == userId);
        }

        public async Task ApproveReservationAsync(int reservationId, int approverId)
        {
            var reservation = await GetByIdAsync(reservationId);
            reservation.Status = ReservationStatus.Approved;
            reservation.ApprovedById = approverId;
            reservation.ApprovedAt = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task RejectReservationAsync(int reservationId, int approverId, string reason)
        {
            var reservation = await GetByIdAsync(reservationId);
            reservation.Status = ReservationStatus.Cancelled;
            reservation.ApprovedById = approverId;
            reservation.Notes = reason;
            await _unitOfWork.CompleteAsync();
        }

        public async Task CancelReservationAsync(int reservationId)
        {
            var reservation = await GetByIdAsync(reservationId);
            reservation.Status = ReservationStatus.Cancelled;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> IsAssetAvailableAsync(int assetId, DateTime start, DateTime end)
        {
            var reservations = await GetReservationsForAssetAsync(assetId);
            return !reservations.Any(r =>
                r.Status != ReservationStatus.Cancelled &&
                r.StartDate < end && r.EndDate > start);
        }
    }
}
