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
                .WithMessage("Required")
                .Matches(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$")
                .WithMessage("Invalid IPv4 format.");

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
