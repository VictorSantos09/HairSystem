using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class BarberValidator : AbstractValidator<BarberEntity>
    {
        public BarberValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().When(x => x.Email != null).WithMessage("Email deve ser fornecido adequadamente");

            RuleFor(x => x.Salary).NotNull().NotEmpty().LessThanOrEqualTo(0).WithMessage("Salário deve ser fornecido");

            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(12).WithMessage("Telefone deve ser fornecido. Exemplo: (47) 99145-8789");

            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(5).WithMessage("Nome deve ser fornecido");

            RuleFor(x => x.SaloonName).NotNull().NotEmpty().MinimumLength(3).WithMessage("Nome do salão deve ser fornecido");

            RuleFor(x => x.SaloonId).NotEmpty().NotNull().WithMessage("ID do salão deve ser fornecido");

            RuleFor(x => x.Hired).NotNull().WithMessage("Deve ser informado se contratado");

            RuleFor(x => x.Id).NotNull().WithMessage("ID deve ser fornecido");
        }
    }
}