using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class ComponentDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new ComponentDto { Name = "RAM", SerialNumber = "SN1" };
            Assert.Equal("RAM", dto.Name);
        } 
    } 
}
