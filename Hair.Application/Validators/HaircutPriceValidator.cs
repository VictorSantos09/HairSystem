using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação dos preços de corte, pela classe concreta <see cref="HaircutPriceEntity"/>
    /// </summary>
    internal class HaircutPriceValidator : AbstractValidator<HaircutPriceEntity>
    {
        public HaircutPriceValidator()
        {
            RuleFor(x => x.Hair).NotEmpty().LessThanOrEqualTo(0).WithName("Corte de cabelo");

            RuleFor(x => x.Mustache).NotNull().LessThanOrEqualTo(0).WithName("Corte de bigode");

            RuleFor(x => x.Beard).NotNull().LessThanOrEqualTo(0).WithName("Corte de barba");
        }
    }
}