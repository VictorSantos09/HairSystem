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
            if (dto.Email == null)
                return BaseDtoExtension.NotNull("Email");

            if (dto.OwnerName == null)
                return BaseDtoExtension.NotNull("Nome do dono");

            if (dto.SaloonName == null)
                return BaseDtoExtension.NotNull("Nome do salão");

            if (dto.Password == null)
                return BaseDtoExtension.NotNull("Senha");

            if (dto.Address.City == null || dto.Address.Street == null)
                return BaseDtoExtension.NotNull("Endereço");

            if (dto.PhoneNumber == null)
                return BaseDtoExtension.NotNull("Telefone");

            if (dto.Name == null)
                return BaseDtoExtension.NotNull("Nome");

            var newUser = new UserEntity(dto.SaloonName, dto.OwnerName, dto.PhoneNumber, dto.Email, dto.Password, dto.Address, dto.CNPJ, dto.HaircutePrice);

            _userRepository.Create(newUser);

            return BaseDtoExtension.Sucess("Conta Criada com sucesso");
        }
    }
}