using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IReservationService
    {
        Task<AssetReservation> CreateReservationAsync(CreateReservationDto dto);
        Task<AssetReservation> GetByIdAsync(int id);
        Task<IEnumerable<AssetReservation>> GetReservationsForAssetAsync(int assetId);
        Task<IEnumerable<AssetReservation>> GetPendingReservationsAsync();
        Task<IEnumerable<AssetReservation>> GetUserReservationsAsync(int userId);
        Task ApproveReservationAsync(int reservationId, int approverId);
        Task RejectReservationAsync(int reservationId, int approverId, string reason);
        Task CancelReservationAsync(int reservationId);
        Task<bool> IsAssetAvailableAsync(int assetId, System.DateTime start, System.DateTime end);
    }
}
