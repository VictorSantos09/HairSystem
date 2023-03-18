using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do usuário, pela classe concreta <see cref="UserEntity"/>, também testando <see cref="AddressEntity"/> e <see cref="HaircutPriceEntity"/>
    /// </summary>
    public class UserValidator : AbstractValidator<UserEntity>
    {

        private readonly IValidator<AddressEntity> _addressValidator;
        public UserValidator(IValidator<AddressEntity> addressValidator)
        {
            _addressValidator = addressValidator;

            RuleFor(x => x.OwnerName).NotEmpty().MinimumLength(5).WithName("Nome do dono");

            RuleFor(x => x.SaloonName).NotEmpty().MinimumLength(3).WithName("Nome do salão");

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithName("Email");

            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(11).WithName("Telefone");

            RuleFor(x => x.CNPJ).MinimumLength(0).Length(14).WithName("CNPJ");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithName("Senha").Custom((password, context) =>
            {
                if (password.All(ch => ch < 33 || ch > 47))
                {
                    context.AddFailure("Senha muito fraca");
                }
            });

            RuleFor(x => x.OpenTime).NotEmpty().WithName("Horário de abertura");

            RuleFor(x => x.CloseTime).NotEmpty().WithName("Horário de fechamento");

            RuleFor(x => x.Address).Custom((address, context) =>
            {
                var addressResult = _addressValidator.Validate(address);

                if (!addressResult.IsValid)
                {
                    var failure = BuildErrorValidation.BuildError(addressResult);

                    context.AddFailure(failure);
                }
            });
        }
    }
}