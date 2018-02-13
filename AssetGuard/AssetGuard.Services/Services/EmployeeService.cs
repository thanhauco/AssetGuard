using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.Repository<Employee>().GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FullName = $"{e.FirstName} {e.LastName}",
                Email = e.Email,
                Department = e.Department,
                AssetCount = 0 // Needs more complex loading logic in real app
            });
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var e = await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
            if (e == null) return null;

            return new EmployeeDto
            {
                Id = e.Id,
                FullName = $"{e.FirstName} {e.LastName}",
                Email = e.Email,
                Department = e.Department,
                AssetCount = 0
            };
        }
    }
}
