using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class ContractValidatorTests
    {
        private readonly ContractValidator _validator = new ContractValidator();

        [Fact]
        public void Should_Require_Positive_Value()
        {
            var model = new Contract { Value = -1 };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
