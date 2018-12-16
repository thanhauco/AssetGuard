using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class DocumentUploadDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new DocumentUploadDto { Title = "Doc1", CategoryId = 1 };
            Assert.Equal("Doc1", dto.Title);
            Assert.Equal(1, dto.CategoryId);
        } 
    } 
}
