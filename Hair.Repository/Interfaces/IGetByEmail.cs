using Hair.Domain.Interfaces;

namespace Hair.Repository.Interfaces
{
    /// <summary>
    /// Define a implementação da busca do <see cref="IUser"/> pelo email e senha
    /// 
    /// <para>Tambem implementando <see cref="IBaseRepository{T}"/> com <see cref="{T}"/> sendo <see cref="IUser"/></para>
    /// </summary>
    public interface IGetByEmail : IBaseRepository<IUser>
    {
        /// <summary>
        /// Efetua a busca do usuário pelo email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Retorna <see cref="IUser"/> do usuário, e <see langword="null"/> se não encontrado</returns>
        IUser? GetByEmail(string email, string password);
    }
}
