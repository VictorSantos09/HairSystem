using Hair.Domain.Entities;

namespace Hair.Repository.Interfaces.CRUD
{
    /// <summary>
    /// Define a implementação da busca do <see cref="UserEntity"/> pelo email e senha
    /// 
    /// <para>Tambem implementando <see cref="IApplicationDbContext{T}"/> com <see cref="{T}"/> sendo <see cref="UserEntity"/></para>
    /// </summary>
    public interface IGetByEmailDbContext : IApplicationDbContext<UserEntity>
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
