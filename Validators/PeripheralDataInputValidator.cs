using FluentValidation;
using GatewaysManager.Models.View;

namespace GatewaysManager.Validators
{
    public class PeripheralDataInputValidator : AbstractValidator<PeripheralInputData>
    {
        public PeripheralDataInputValidator()
        {
            RuleFor(peripheral => peripheral.UID)
                .NotEmpty()
                .WithMessage("Required")
                .NotNull()
                .WithMessage("Required");

            RuleFor(peripheral => peripheral.Status)
                .IsInEnum()
                .WithMessage("Required");

            RuleFor(peripheral => peripheral.Vendor)
                .NotEmpty()
                .WithMessage("Required")
                .NotNull()
                .WithMessage("Required")
                .MaximumLength(90);
        }
    }
}
