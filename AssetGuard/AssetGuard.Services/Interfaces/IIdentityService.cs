using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task RegisterAsync(ApplicationUser user, string password);
    }
}
