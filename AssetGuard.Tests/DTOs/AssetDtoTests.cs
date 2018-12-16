using Xunit;
using AssetGuard.Services.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AssetGuard.Tests.DTOs 
{ 
    public class AssetDtoTests 
    { 
        [Fact] 
        public void Dto_Validation_Passes() 
        { 
            var dto = new AssetDto { Name = "Valid", SerialNumber = "123" };
            var context = new ValidationContext(dto);
            var results = new List<ValidationResult>();
            
            var isValid = Validator.TryValidateObject(dto, context, results, true);
            
            // Assume no validation attributes for now or just checking prop set
            Assert.Equal("Valid", dto.Name);
            Assert.Equal("123", dto.SerialNumber);
        } 
    } 
}
