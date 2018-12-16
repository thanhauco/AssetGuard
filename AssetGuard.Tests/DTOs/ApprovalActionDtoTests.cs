using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class ApprovalActionDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new ApprovalActionDto { Decision = "Approve", Comments = "Good" };
            Assert.Equal("Approve", dto.Decision);
            Assert.Equal("Good", dto.Comments);
        } 
    } 
}
