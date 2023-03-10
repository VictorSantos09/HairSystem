using FluentValidation;
using Hair.Domain.Entities;

namespace Hair.Application.Validators
{
    /// <summary>
    /// Efetua a validação da imagem, pela classe concreta <see cref="ImageEntity"/>
    /// </summary>
    internal class ImageValidator : AbstractValidator<ImageEntity>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.SaloonId).NotEmpty().WithName("ID do salão");

            RuleFor(x => x.Image).NotEmpty().WithName("Imagem");
        }
    }
}