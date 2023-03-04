using FluentValidation;
using FluentValidation.Results;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class HaircutValidator : AbstractValidator<HaircutEntity>
    {
        private readonly IValidator<ClientEntity> _clientValidator;
        public HaircutValidator(IValidator<ClientEntity> validator)
        {
            _clientValidator = validator;

            RuleFor(x => x.HaircuteTime).NotEmpty().NotNull().WithName("Horário de corte");

            RuleFor(x => x.Available).NotNull().NotEmpty().WithName("Disponibilidade");

            RuleFor(x => x.SaloonId).NotNull().NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Client).Custom((client, context) =>
            {
                var clientResult = _clientValidator.Validate(client);

                if (!clientResult.IsValid)
                {
                    context.AddFailure(BuildClientError(clientResult).ToString());
                }
            });
        }

        private List<string> BuildClientError(ValidationResult result)
        {
            if (result.IsValid)
            {
                return new List<string>();
            }

            var output = new List<string>();
            foreach (var error in result.Errors)
            {
                output.Add(error.ErrorMessage);
            }

            return output;
        }
    }
}