using System.Collections.Generic;

namespace AssetGuard.Services.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int AssetCount { get; set; }
    }
}
