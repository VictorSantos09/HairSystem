using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces.UserCases
{
    public interface IRegister
    {

        /// <summary>
        /// Efetua a criação de um novo usuário.
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com status code 200 quando concluido com sucesso.
        /// </returns>
        BaseDto Register(RegisterDto dto);
    }
}