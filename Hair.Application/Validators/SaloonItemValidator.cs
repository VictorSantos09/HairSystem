using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do item do salão, pela classe concreta <see cref="ItemEntity"/>
    /// </summary>
    public class SaloonItemValidator : AbstractValidator<ItemEntity>
    {
        public SaloonItemValidator()
        {
            RuleFor(x => x.Price).NotEmpty().LessThanOrEqualTo(0).WithName("Preço");

            RuleFor(x => x.QuantityAvaible).NotEmpty().LessThanOrEqualTo(0).WithName("Quantidade Disponível");

            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithName("Nome do item");

            RuleFor(x => x.UserID).NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Id).NotEmpty().WithName("ID");
        }
    }
}
