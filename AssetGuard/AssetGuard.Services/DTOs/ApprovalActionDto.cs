namespace AssetGuard.Services.DTOs
{
    public class ApprovalActionDto
    {
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }
        public string Comments { get; set; }
    }
}
