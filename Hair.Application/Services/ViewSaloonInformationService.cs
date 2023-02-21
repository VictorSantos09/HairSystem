using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class ViewSaloonInformationService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public ViewSaloonInformationService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto GetInformation(ViewSaloonInformationDto dto)
        {
            var user = _userRepository.GetById(dto.UserId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            object saloonInformation = new
            {
                user.Adress,
                user.PhoneNumber,
                user.Email,
                user.SaloonName,
                user.Prices.Hair,
                user.Prices.Beard,
                user.Prices.Mustache,
                user.CNPJ,
            };

            return BaseDtoExtension.Create(200, $"Informações do salão {user.SaloonName}", saloonInformation);
        }
    }
}