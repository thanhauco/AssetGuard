using System.ComponentModel.DataAnnotations;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.DTOs
{
    public class CreateIssueDto
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int AssetId { get; set; }
        
        public IssuePriority Priority { get; set; }
    }
}
