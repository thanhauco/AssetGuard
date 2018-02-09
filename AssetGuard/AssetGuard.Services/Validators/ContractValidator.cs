using FluentValidation;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Validators
{
    public class ContractValidator : AbstractValidator<Contract>
    {
        public ContractValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Value).GreaterThan(0);
            RuleFor(x => x.VendorId).GreaterThan(0);
        }
    }
}
