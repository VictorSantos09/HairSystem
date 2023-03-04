using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class ClientValidator : AbstractValidator<ClientEntity>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).WithName("Nome do cliente");

            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().Length(11).WithName("Telefone");

            RuleFor(x => x.Id).NotEmpty().NotNull().WithName("ID");
        }
    }
}