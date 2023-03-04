using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class HaircutPriceValidator : AbstractValidator<HaircutPriceEntity>
    {
        public HaircutPriceValidator()
        {
            RuleFor(x => x.Hair).NotEmpty().NotNull().LessThanOrEqualTo(0).WithMessage("Corte de cabelo deve ser informado");

            RuleFor(x => x.Mustache).NotEmpty().NotNull().LessThanOrEqualTo(0).WithMessage("Corte de bigode deve ser informado");

            RuleFor(x => x.Beard).NotEmpty().NotNull().LessThanOrEqualTo(0).WithMessage("Corte de barba deve ser informado");
        }
    }
}