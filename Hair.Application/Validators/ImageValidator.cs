using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    internal class ImageValidator : AbstractValidator<ImageEntity>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            
            RuleFor(x => x.SaloonId).NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Img).NotEmpty().WithName("Imagem");
        }
    }
}