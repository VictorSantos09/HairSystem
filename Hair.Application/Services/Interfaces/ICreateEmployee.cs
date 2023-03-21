using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Services.Interfaces
{
    public interface ICreateEmployee
    {
        /// <summary>
        /// Efetua a criação de um novo funcionário se confirmado <see langword="true"/>.
        /// </summary>
        /// 
        /// <param name="dto">DTO contendo os dados necessários para a efetuação.</param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com status code 200 quando efetuado com sucesso.
        /// </returns>
        BaseDto Create(CreateEmployeeDto dto);
    }
}