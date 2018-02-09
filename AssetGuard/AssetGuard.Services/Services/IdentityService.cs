using System;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Exceptions;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IdentityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            // Simplified auth logic
            var users = await _unitOfWork.Repository<ApplicationUser>().FindAsync(u => u.Username == request.Username);
            var user = System.Linq.Enumerable.FirstOrDefault(users);

            if (user == null || user.PasswordHash != request.Password) // In real app, hash check
            {
                throw new BadRequestException("Invalid credentials");
            }

            return new LoginResponse
            {
                Token = "fake-jwt-token-for-simulation",
                Username = user.Username,
                ExpirationMinutes = 60
            };
        }

        public async Task RegisterAsync(ApplicationUser user, string password)
        {
            user.PasswordHash = password; // In real app, hash this
            await _unitOfWork.Repository<ApplicationUser>().AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
