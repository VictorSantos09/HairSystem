using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do barbeiro, pela classe concreta <see cref="BarberEntity"/>, também testando <see cref="AddressEntity"/>
    /// </summary>
    public class BarberValidator : AbstractValidator<BarberEntity>
    {
        private readonly IValidator<AddressEntity> _addressValidator;
        public BarberValidator(IValidator<AddressEntity> addressValidator)
        {
            _addressValidator = addressValidator;

            RuleFor(x => x.Email).NotNull().EmailAddress().WithName("Email");

            RuleFor(x => x.Salary).NotEmpty().GreaterThan(0).WithName("Salário");

            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(12).WithName("Telefone");

            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).WithName("Nome");

            RuleFor(x => x.SaloonName).NotEmpty().MinimumLength(3).WithName("Nome do salão");

            RuleFor(x => x.SaloonId).NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Hired).NotEmpty().WithName("Contratado");

            RuleFor(x => x.Id).NotEmpty().WithName("ID");

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