using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Classe referente para efetuar a remoção da conta.
    /// 
    /// </summary>
    public class DeleteAccountService
    {
        private readonly IGetByEmail _userRepository;

        public DeleteAccountService(IGetByEmail userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Efetua a remoção da conta com as informações passadas.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto com as informações da conta.</param>
        /// 
        /// <returns>Retorna a remoção da conta em caso de sucesso ou inválido.</returns>
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