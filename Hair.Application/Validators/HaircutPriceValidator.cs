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
            RuleFor(x => x.Hair).NotEmpty().GreaterThan(0).WithName("Corte de cabelo");

            RuleFor(x => x.Mustache).NotNull().WithName("Corte de bigode");

            RuleFor(x => x.Beard).NotNull().WithName("Corte de barba");
        }
    }
}