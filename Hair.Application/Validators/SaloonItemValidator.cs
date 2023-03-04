using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class SaloonItemValidator : AbstractValidator<SaloonItemEntity>
    {
        public SaloonItemValidator()
        {
            RuleFor(x => x.Price).NotNull().NotEmpty().LessThanOrEqualTo(0).WithName("Preço");

            RuleFor(x => x.QuantityAvaible).NotEmpty().NotNull().LessThanOrEqualTo(0).WithName("Quantidade Disponível");

            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).WithName("Nome do item");

            RuleFor(x => x.SaloonId).NotNull().NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Id).NotEmpty().NotNull().WithName("ID");
        }
    }
}
