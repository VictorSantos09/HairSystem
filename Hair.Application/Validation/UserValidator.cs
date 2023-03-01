using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validation
{
    internal class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.OwnerName).NotEmpty().NotNull().MinimumLength(5).WithMessage("Nome inválido");
            RuleFor(x => x.SaloonName).NotEmpty().NotNull().MinimumLength(3).WithMessage("Nome do salão inválido");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Email inválido");
            RuleFor(x => x.CNPJ).NotEmpty().NotNull().Length(14).WithMessage("CNPJ inválido");
            RuleFor(x => x.Address).NotNull().WithMessage("Endereço inválido");
            RuleFor(x => x.Address.Number).NotNull().NotEmpty().WithMessage("Número de endereço inválido");
            RuleFor(x => x.Address.City).NotNull().NotEmpty().WithMessage("Cidade inválida");
            RuleFor(x => x.Address.State).NotNull().NotEmpty().Length(2).WithMessage("Estado inválido");
            RuleFor(x => x.Password).NotNull().NotEmpty().Must(x => x.Length > 0).WithMessage("Senha muito fraca");
            RuleFor(x => x.OpenTime).NotEmpty().NotNull().WithMessage("Horário de abertura inválido");
            RuleFor(x => x.CloseTime).NotEmpty().NotNull().WithMessage("Horário de fechamento inválido");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().Length(11).WithMessage("Telefone inválido");
        }
    }
}
