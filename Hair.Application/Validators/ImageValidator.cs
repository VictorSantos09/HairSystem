using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação da imagem, pela classe concreta <see cref="ImageEntity"/>
    /// </summary>
    public class ImageValidator : AbstractValidator<ImageEntity>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.UserID).NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Image).NotEmpty().WithName("Imagem");
        }
    }
}