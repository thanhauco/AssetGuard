namespace AssetGuard.Services.DTOs
{
    public class SubmitApprovalDto
    {
        public string WorkflowName { get; set; } // To lookup ID
        public string RequestDetails { get; set; }
    }
}
