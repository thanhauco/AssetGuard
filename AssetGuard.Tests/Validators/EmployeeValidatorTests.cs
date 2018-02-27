using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class EmployeeValidatorTests
    {
        private readonly EmployeeValidator _validator = new EmployeeValidator();

        [Fact]
        public void Should_Have_Error_When_Email_Invalid()
        {
            var model = new Employee { Email = "invalid" };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
