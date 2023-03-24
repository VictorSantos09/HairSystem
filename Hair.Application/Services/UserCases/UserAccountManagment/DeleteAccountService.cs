using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services.UserCases.UserAccountManagment
{
    /// <summary>
    /// Classe referente para efetuar a remoção da conta.
    /// </summary>
    public sealed class DeleteAccountService : IDeleteAccount
    {
        private readonly IGetByEmailDbContext _userRepository;

        public DeleteAccountService(IGetByEmailDbContext userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto Delete(DeleteAccountDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetByEmail(dto.Email, dto.Password);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (user.Email != dto.Email || user.Password != dto.Password)
                return BaseDtoExtension.Invalid("Email ou senha inválidos");

            if (dto.CNPJ != null && dto.CNPJ != user.CNPJ)
                return BaseDtoExtension.Invalid("CNPJ incorreto");

            _userRepository.Remove(user.Id);

            return BaseDtoExtension.Sucess("Conta deletada com sucesso");
        }
    }
}