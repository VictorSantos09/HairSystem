using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class ImageValidator : AbstractValidator<ImageEntity>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            
            RuleFor(x => x.SaloonId).NotEmpty().NotNull().WithName("ID do salão");

            RuleFor(x => x.Img).NotNull().NotEmpty().WithName("Imagem");
        }
    }
}