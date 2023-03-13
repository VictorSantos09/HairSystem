using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do cliente, pela classe concreta <see cref="ClientEntity"/>
    /// </summary>
    public class ClientValidator : AbstractValidator<ClientEntity>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithName("Nome do cliente");

            RuleFor(x => x.PhoneNumber).NotEmpty().Length(11).WithName("Telefone");

            RuleFor(x => x.Id).NotEmpty().WithName("ID");

            RuleFor(x => x.Email).NotNull();
        }
    }
}