using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases
{
    /// <summary>
    /// 
    /// Define a função de postar uma nova imagem.
    /// 
    /// </summary>
    public class PostImageService
    {
        private readonly IBaseRepository<ImageEntity> _imageRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IValidator<ImageEntity> _imageValidator;

        public PostImageService(IBaseRepository<ImageEntity> imageRepository, IBaseRepository<UserEntity> userRepository, IValidator<ImageEntity> imageValidator)
        {
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _imageValidator = imageValidator;
        }

        /// <summary>
        /// 
        /// Efetua a postagem de uma nova imagem para o usuário.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// 
        /// Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada.
        /// 
        /// </returns>
        public BaseDto Post(PostImageDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (dto.Image == null)
                return BaseDtoExtension.NotNull("Imagem");

            byte[] imageByte = Convert.FromHexString(dto.Image.ToString());

            var resultDate = new DateOnly();
            if (DateOnly.TryParse(dto.UploadDate, out resultDate) == false)
                return BaseDtoExtension.Invalid("Data de postagem");

            var img = new ImageEntity(user.Id, imageByte, resultDate, dto.Type);

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