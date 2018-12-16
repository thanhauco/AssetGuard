using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class VendorDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new VendorDto { Name = "V1", ContactEmail = "e@v1.com" };
            Assert.Equal("V1", dto.Name);
        } 
    } 
}
