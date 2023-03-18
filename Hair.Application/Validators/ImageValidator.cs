using FluentValidation;
using FluentValidation.Results;
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
            RuleFor(x => x.UserID).NotEmpty().WithName("ID do usuário");
            RuleFor(x => x.Image).NotEmpty().WithName("Imagem");
            RuleFor(x => x.UploadDate).NotEmpty().WithName("Data de upload");
            RuleFor(x => x.Type).NotEmpty().MaximumLength(4).MinimumLength(3).WithName("Tipo de imagem").Custom((type, context) =>
            {
                if (type.Contains("."))
                {
                    ValidationFailure failure = new ValidationFailure(type.ToString(),"tipo de imagem não deve conter ' . '");
                    context.AddFailure(failure);
                }
            });
        }
    }
}