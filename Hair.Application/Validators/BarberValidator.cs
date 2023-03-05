using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do barbeiro, pela classe concreta <see cref="BarberEntity"/>
    /// </summary>
    internal class BarberValidator : AbstractValidator<BarberEntity>
    {
        public BarberValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Email deve ser fornecido adequadamente");

            RuleFor(x => x.Salary).NotEmpty().LessThanOrEqualTo(0).WithMessage("Salário deve ser fornecido");

            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(12).WithMessage("Telefone deve ser fornecido. Exemplo: (47) 99145-8789");

            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).WithMessage("Nome deve ser fornecido");

            RuleFor(x => x.SaloonName).NotEmpty().MinimumLength(3).WithMessage("Nome do salão deve ser fornecido");

            RuleFor(x => x.SaloonId).NotEmpty().WithMessage("ID do salão deve ser fornecido");

            RuleFor(x => x.Hired).NotEmpty().WithMessage("Deve ser informado se contratado");

            RuleFor(x => x.Id).NotEmpty().WithMessage("ID deve ser fornecido");
        }
    }
}