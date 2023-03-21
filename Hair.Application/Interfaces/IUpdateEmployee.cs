using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces
{
    public interface IUpdateEmployee
    {
        /// <summary>
        /// Efetua a atualização de um funcionário.
        /// </summary>
        /// 
        /// <param name="dto">Dados necessários para atualizar</param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com status code 200 quando efetuado com sucesso.
        /// </returns>
        BaseDto Update(UpdateEmployeeDto dto);
    }
}