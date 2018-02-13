using System;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;

namespace AssetGuard.Services.Interfaces
{
    public interface IAuditService
    {
        Task LogAsync(string action, string controller, string arguments, string username, string ip);
    }

    public class AuditService : IAuditService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task LogAsync(string action, string controller, string arguments, string username, string ip)
        {
            var log = new AuditLog
            {
                Action = action,
                ControllerName = controller,
                Arguments = arguments,
                Username = username,
                Timestamp = DateTime.UtcNow,
                IpAddress = ip
            };

            await _unitOfWork.Repository<AuditLog>().AddAsync(log);
            await _unitOfWork.CompleteAsync();
        }
    }
}
