using Hair.Application.Common;

namespace Hair.Application.Interfaces.UserCases
{
    public interface IViewEmployeeData
    {
        /// <summary>
        /// Efetua a busca dos funcionários do usuário.
        /// </summary>
        /// 
        /// <param name="userEmail">Email do usuário.</param>
        /// <param name="userPassword">Senha do usuário.</param>
        /// 
        /// <returns>
        /// Retorna <see cref="BaseDto"/> com Data sendo os funcionários quando encontrado e status code 200.
        /// </returns>
        BaseDto GetEmployeeData(string userEmail, string userPassword);
    }
}