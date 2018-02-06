using System;

namespace AssetGuard.Services.DTOs
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string AssetName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
