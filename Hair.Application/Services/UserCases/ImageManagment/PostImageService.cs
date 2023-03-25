using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.ImageManagment
{
    /// <summary>
    /// 
    /// Define a função de postar uma nova imagem.
    /// 
    /// </summary>
    public sealed class PostImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<ImageEntity> _imageValidator;
        private readonly IFactory _factory;

        public PostImageService(IImageRepository imageRepository, IUserRepository userRepository, IValidator<ImageEntity> imageValidator, IFactory factory)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _imageValidator = imageValidator;
            _factory = factory;
        }

        /// <summary>
        /// Efetua a postagem de uma nova imagem para o usuário.
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada.
        /// </returns>
        public BaseDto Post(PostImageDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (dto.Image == null)
                return BaseDtoExtension.NotNull("Imagem");

            byte[] imageByte = Convert.FromHexString(dto.Image.ToString());

            DateOnly resultDate;
            if (DateOnly.TryParse(dto.UploadDate, out resultDate) == false)
                return BaseDtoExtension.Invalid("Data de postagem");

            var img = _factory.Image.Create(user.Id, imageByte, resultDate, dto.Type);

            var validationResult = Validation.Verify(_imageValidator.Validate(img));

            if (validationResult.Condition)
            {
                _imageRepository.Create(img);
                return BaseDtoExtension.Sucess();
            }

            return Validation.ToBaseDto(validationResult);
        }
    }
}