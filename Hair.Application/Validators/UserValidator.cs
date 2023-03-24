using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do <see cref="UserEntity"/>
    /// </summary>
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
            RuleFor(x => x.SaloonName).NotEmpty().MaximumLength(50).WithName("Nome do salão");
            RuleFor(x => x.OwnerName).NotEmpty().MaximumLength(50).WithName("Nome do proprietário");
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(50).WithName("Telefone");
            RuleFor(x => x.Email).EmailAddress().MaximumLength(50);
            RuleFor(x => x.Password).MinimumLength(8).MaximumLength(50).WithName("Senha").Custom((password, context) =>
            {
                if (password.All(asciiSpecialCaracter => asciiSpecialCaracter < 33 || asciiSpecialCaracter > 47))
                {
                    context.AddFailure("Senha muito fraca");
                }
            });
            RuleFor(x => x.CNPJ).MaximumLength(50).WithName("CNPJ");
            RuleFor(x => x.OpenTime).NotEmpty().WithName("Horário de abertura");
            RuleFor(x => x.CloseTime).NotEmpty().WithName("Horário de fechamento");
        }
    }
}