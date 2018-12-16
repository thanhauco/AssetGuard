using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class SubmitApprovalDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new SubmitApprovalDto { WorkflowName = "WF1", RequestData = "{}" };
            Assert.Equal("WF1", dto.WorkflowName);
        } 
    } 
}
