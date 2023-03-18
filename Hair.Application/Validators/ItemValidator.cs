using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do item do salão, pela classe concreta <see cref="ItemEntity"/>
    /// </summary>
    public class ItemValidator : AbstractValidator<ItemEntity>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserID).NotEmpty().WithName("Id do usuário");
            RuleFor(x => x.Type).SetValidator(new ItemTypeValidator());
            RuleFor(x => x.Description).MaximumLength(50).WithName("Descrição");
            RuleFor(x => x.Price).NotNull().WithName("Preço");
            RuleFor(x => x.QuantityAvaible).NotNull().WithName("Quantidade Disponível");
        }
    }
}