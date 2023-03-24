using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    public class ProductTypeValidator : AbstractValidator<ProductTypeEntity>
    {
        public ProductTypeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithName("Nome");
            RuleFor(x => x.Code).NotEmpty().GreaterThan(0).WithName("Código");
        }
    }
}