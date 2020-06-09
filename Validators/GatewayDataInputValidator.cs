using FluentValidation;
using GatewaysManager.Models.View;

namespace GatewaysManager.Validators
{
    public class GatewayDataInputValidator : AbstractValidator<GatewayInputData>
    {
        public GatewayDataInputValidator()
        {
            RuleFor(gateway => gateway.IPv4)
                .NotEmpty()
                .WithMessage("Required")
                .NotNull()
                .WithMessage("Required");

            RuleFor(gateway => gateway.Name)
                .NotEmpty()
                .WithMessage("Required")
                .NotNull()
                .WithMessage("Required")
                .MaximumLength(90);

            RuleFor(gateway => gateway.SerialNumber)
                .NotEmpty()
                .WithMessage("Required")
                .NotNull()
                .WithMessage("Required");
        }
    }
}
