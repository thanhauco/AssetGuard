using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class LicenseDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new LicenseDto { SoftwareName = "Office", LicenseKey = "KEY" };
            Assert.Equal("Office", dto.SoftwareName);
        } 
    } 
}
