using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class ReportRequestDtoTests 
    { 
        [Fact] 
        public void Dto_Properties() 
        { 
            var dto = new ReportRequestDto { StartDate = System.DateTime.Now, Format = "PDF" };
            Assert.Equal("PDF", dto.Format);
        } 
    } 
}
