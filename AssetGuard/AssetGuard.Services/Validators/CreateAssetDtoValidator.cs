using FluentValidation;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Validators
{
    public class CreateAssetDtoValidator : AbstractValidator<CreateAssetDto>
    {
        public CreateAssetDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.SerialNumber).NotEmpty();
            RuleFor(x => x.PurchasePrice).GreaterThan(0);
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
