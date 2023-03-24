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
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserID).NotEmpty().WithName("Id do usuário");
            RuleFor(x => x.Duty).SetValidator(new ServiceOrderValidator());
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithName("Nome");
            RuleFor(x => x.Email).MaximumLength(50).Custom((email, context) =>
            {
                if (email != null)
                {
                    RuleFor(x => x.Email).EmailAddress();
                }
            });
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(50).WithName("Telefone");
        }
    }
}