using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Services.Interfaces
{
    public interface IDeleteAccount
    {
        /// <summary>
        /// Efetua a remoção da conta do usuário.
        /// </summary>
        /// 
        /// <param name="dto">Dados necessários para efetuar a remoção da conta.</param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com status code 200 quando conta removida.
        /// </returns>
        BaseDto Delete(DeleteAccountDto dto);
    }
}