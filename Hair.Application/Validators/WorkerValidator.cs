using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do funcionário, pela classe concreta <see cref="EmployeeEntity"/>, também testando <see cref="AddressEntity"/>
    /// </summary>
    public class WorkerValidator : AbstractValidator<EmployeeEntity>
    {
        public WorkerValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserID).NotEmpty().WithName("Id do usuário");
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
            RuleFor(x => x.FunctionType).SetValidator(new FunctionTypeValidator());
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithName("Nome");
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(50).WithName("Telefone");
            RuleFor(x => x.Email).Custom((email, context) =>
            {
                if (email != null)
                {
                    RuleFor(x => x.Email).EmailAddress();
                }
            });
            RuleFor(x => x.Salary).NotEmpty().WithName("Salário");
        }
    }
}