using FluentValidation;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Validators
{
    public class CreateMaintenanceRecordDtoValidator : AbstractValidator<CreateMaintenanceRecordDto>
    {
        public CreateMaintenanceRecordDtoValidator()
        {
            RuleFor(x => x.AssetId).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Cost).GreaterThanOrEqualTo(0);
            RuleFor(x => x.MaintenanceDate).NotEmpty();
        }
    }
}
