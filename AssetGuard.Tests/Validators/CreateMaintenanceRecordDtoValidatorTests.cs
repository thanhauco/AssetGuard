using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Validators
{
    public class CreateMaintenanceRecordDtoValidatorTests
    {
        private readonly CreateMaintenanceRecordDtoValidator _validator = new CreateMaintenanceRecordDtoValidator();

        [Fact]
        public void Should_Have_Error_When_MaintenanceDate_Empty()
        {
            var model = new CreateMaintenanceRecordDto();
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
