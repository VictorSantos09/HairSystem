using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.OwnerName).NotEmpty().NotNull().MinimumLength(5).WithName("Nome do dono");

            RuleFor(x => x.SaloonName).NotEmpty().NotNull().MinimumLength(3).WithName("Nome do salão");

            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithName("Email");

            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().MaximumLength(11).WithName("Telefone");

            RuleFor(x => x.CNPJ).NotEmpty().NotNull().Length(14).WithName("CNPJ");

            RuleFor(x => x.Address.CEP).NotEmpty().NotNull().Length(8).WithName("CEP");

            RuleFor(x => x.Address.Number).NotNull().NotEmpty().WithName("Número de endereço");

            RuleFor(x => x.Address.City).NotNull().NotEmpty().WithName("Cidade");

            RuleFor(x => x.Address.State).NotEmpty().NotNull().Length(2).WithName("Estado");

            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8).WithName("Senha").Custom((password, context) =>
            {
                if (password.All(ch => ch < 33 || ch > 47))
                {
                    context.AddFailure("Senha muito fraca");
                }
            });

            RuleFor(x => x.OpenTime).NotEmpty().NotNull().WithName("Horário de abertura");

            RuleFor(x => x.CloseTime).NotEmpty().NotNull().WithName("Horário de fechamento");

            RuleFor(x => x.Prices.Hair).LessThanOrEqualTo(0).WithName("Corte de cabelo");

            RuleFor(x => x.Prices.Mustache).LessThanOrEqualTo(0).WithName("Corte de bigode");

            RuleFor(x => x.Prices.Beard).LessThanOrEqualTo(0).WithName("Corte de barba");
        }
    }
}