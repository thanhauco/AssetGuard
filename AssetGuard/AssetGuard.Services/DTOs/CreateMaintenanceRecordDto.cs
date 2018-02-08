using System;
using System.ComponentModel.DataAnnotations;

namespace AssetGuard.Services.DTOs
{
    public class CreateMaintenanceRecordDto
    {
        [Required]
        public int AssetId { get; set; }
        
        [Required]
        public DateTime MaintenanceDate { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public decimal Cost { get; set; }
        
        public string ServiceProvider { get; set; }
    }
}
