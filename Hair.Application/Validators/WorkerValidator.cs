using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do funcionário, pela classe concreta <see cref="WorkerEntity"/>, também testando <see cref="AddressEntity"/>
    /// </summary>
    public class WorkerValidator : AbstractValidator<WorkerEntity>
    {
        private readonly IValidator<AddressEntity> _addressValidator;
        public WorkerValidator(IValidator<AddressEntity> addressValidator)
        {
            _addressValidator = addressValidator;

            RuleFor(x => x.Email).NotNull().EmailAddress().WithName("Email");

            RuleFor(x => x.Salary).NotEmpty().GreaterThan(0).WithName("Salário");

            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(12).WithName("Telefone");

            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).WithName("Nome");

            RuleFor(x => x.UserID).NotEmpty().WithName("ID do usuário");

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