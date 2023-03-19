using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    public class ServiceValidator : AbstractValidator<TaskEntity>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithName("ID do usuário");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30).WithName("Nome do serviço");
            RuleFor(x => x.Type).SetValidator(new ServiceTypeValidator());
            RuleFor(x => x.Value).NotEmpty().GreaterThan(0).WithName("Valor");
            RuleFor(x => x.Description).MaximumLength(75).WithName("Descrição");
        }
    }
}