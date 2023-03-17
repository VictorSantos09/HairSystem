using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação do corte de cabelo, pela classe concreta <see cref="DutyEntity"/>, também testando <see cref="ClientEntity"/>
    /// </summary>
    public class HaircutValidator : AbstractValidator<DutyEntity>
    {
        private readonly IValidator<ClientEntity> _clientValidator;
        public HaircutValidator(IValidator<ClientEntity> validator)
        {
            _clientValidator = validator;

            RuleFor(x => x.Date).NotEmpty().WithName("Horário de corte");

            RuleFor(x => x.Available).NotEmpty().WithName("Disponibilidade");

            RuleFor(x => x.UserID).NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Client).Custom((client, context) =>
            {
                var clientResult = _clientValidator.Validate(client);

                if (!clientResult.IsValid)
                {
                    var failure = BuildErrorValidation.BuildError(clientResult);
                    context.AddFailure(failure);
                }
            });
        }
    }
}