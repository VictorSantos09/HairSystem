using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces
{
    public interface IGetByEmail
    {
        /// <summary>
        /// Efetua a busca do usuário pelo email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Retorna <see cref="UserEntity"/> do usuário, e <see langword="null"/> se não encontrado</returns>
        UserEntity? GetByEmail(string email, string password);
    }
}
