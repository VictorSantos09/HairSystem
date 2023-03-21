using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces
{
    public interface IDeleteEmployee
    {

        /// <summary>
        /// Efetua a remoção de um funcionário.
        /// </summary>
        /// 
        /// <param name="dto">DTO com os dados necessários para processar.</param>
        /// 
        /// <returns>
        /// Retorna um <see cref="BaseDto"/> Com status code 200 quando efetuado com sucesso.
        /// </returns>
        BaseDto Delete(DeleteEmployeeDto dto);
    }
}