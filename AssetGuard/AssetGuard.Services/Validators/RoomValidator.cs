using FluentValidation;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Number).NotEmpty();
            RuleFor(x => x.Capacity).GreaterThan(0);
        }
    }
}
