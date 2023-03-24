using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces.UserCases
{
    public interface IEmployeeManagment
    {
        /// <summary>
        /// Método que demite um funcionário existente.
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo <see cref="DeleteEmployeeDto"/> contendo as informações do funcionário a ser demitido.</param>
        /// 
        /// <returns>
        /// Objeto do tipo BaseDto com o resultado da operação de demissão.
        /// </returns>
        BaseDto Fire(DeleteEmployeeDto dto);

        /// <summary>
        /// Método que contrata um novo funcionário.
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo <see cref="CreateEmployeeDto"/> contendo as informações do novo funcionário a ser contratado.</param>
        /// 
        /// <returns>
        /// Objeto do tipo BaseDto com o resultado da operação de contratação.
        /// </returns>
        BaseDto Hire(CreateEmployeeDto dto);
        /// <summary>
        /// Método que atualiza as informações de um funcionário existente
        /// </summary>
        /// 
        /// <param name="dto">Objeto do tipo <see cref="UpdateEmployeeDto"/> contendo as informações atualizadas do funcionário.</param>
        /// 
        /// <returns>
        /// Objeto do tipo BaseDto com o resultado da operação de atualização.
        /// </returns>
        BaseDto Update(UpdateEmployeeDto dto);
    }
}