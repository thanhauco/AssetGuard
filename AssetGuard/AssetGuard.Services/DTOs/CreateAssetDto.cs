using System;
using System.ComponentModel.DataAnnotations;

namespace AssetGuard.Services.DTOs
{
    public class CreateAssetDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string SerialNumber { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime PurchaseDate { get; set; }
        
        [Required]
        public decimal PurchasePrice { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
    }
}
