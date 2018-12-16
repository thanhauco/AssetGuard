using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class SiteDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new SiteDto { Name = "HQ", Address = "123 Main" };
            Assert.Equal("HQ", dto.Name);
            Assert.Equal("123 Main", dto.Address);
        } 
    } 
}
