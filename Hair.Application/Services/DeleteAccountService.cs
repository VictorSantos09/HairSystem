using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class DeleteAccountService
    {
        private readonly IGetByEmail _userRepository;

        public DeleteAccountService(IGetByEmail userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto Delete(DeleteAccountDto dto)
        {
            var user = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (user.Email != dto.Email || user.Password != dto.Password || user.CNPJ != dto.CNPJ)
                return BaseDtoExtension.Invalid("Um dado ou mais inválidos");

            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            _userRepository.Remove(user.Id);

            return BaseDtoExtension.Sucess("Conta deletada com sucesso");
        }
    }
}