using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class FunctionTypeValidator : AbstractValidator<FunctionTypeEntity>
    {
        public FunctionTypeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Nome");
            RuleFor(x => x.Code).NotEmpty().GreaterThan(0).WithName("Código");
        }
    }
}