using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class CreateIssueDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new CreateIssueDto { Title = "Bug", Priority = 1 };
            Assert.Equal("Bug", dto.Title);
            Assert.Equal(1, dto.Priority);
        } 
    } 
}
