using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces
{
    public interface ILogin
    {
        /// <summary>
        /// Efetua o processo de login.
        /// </summary>
        /// 
        /// <param name="dto">Dados necessários para efetuar o login.</param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com status code 200 quando bem sucedido, também fornecendo a ID do usuário.
        /// </returns>
        BaseDto Login(LoginDto dto);
    }
}