using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class RegisterService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public RegisterService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto Execute(RegisterDto dto)
        {
            var newUser = new UserEntity(dto.SaloonName, dto.OwnerName, dto.PhoneNumber, dto.Email, dto.Password, dto.Address, dto.CNPJ, dto.HaircutePrice);

            _userRepository.Create(newUser);

            return BaseDtoExtension.Sucessfull("Conta Criada com sucesso");
        }
    }
}
