using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do endereço, pela classe concreta <see cref="AddressEntity"/>
    /// </summary>
    public class AddressValidator : AbstractValidator<AddressEntity>
    {
        public AddressValidator()
        {
            RuleFor(x => x.CEP).NotEmpty().Length(8).WithName("CEP");

            RuleFor(x => x.Number).NotNull().WithName("Número de endereço");

            RuleFor(x => x.City).NotEmpty().WithName("Cidade");

            RuleFor(x => x.State).NotEmpty().Length(2).WithName("Estado");
        }
    }
}