using FluentValidation;
using FluentValidation.Results;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do corte de cabelo, pela classe concreta <see cref="DutyEntity"/>, também testando <see cref="ClientEntity"/>
    /// </summary>
    public class DutyValidator : AbstractValidator<DutyEntity>
    {
        public DutyValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserID).NotEmpty().WithName("ID do usuário");
            RuleFor(x => x.Client).SetValidator(new ClientValidator()).WithName("Cliente");
            RuleFor(x => x.ServiceType).SetValidator(new ServiceTypeValidator()).WithName("Tipo do serviço");
            RuleFor(x => x.Date).NotEmpty().WithName("Data").Custom((date, context) =>
            {
                if (date < DateTime.Today)
                {
                    ValidationFailure failure = new ValidationFailure(date.ToString(), "Não é possível agendar para dia anterior");

                    context.AddFailure(failure);
                }
            });
        }
    }
}