using Dapper;
using Hair.Domain.Common;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Base Principal dos repositorios onde efetua a ação escolhida, contendo as funções implementadas da interface <see cref="IBaseRepository{T}"/>
    /// Todos os repositories existente DEVEM herdar dessa classe.
    /// </summary>
    
    public class BaseRepository<T> : IRemove, IGetAll<T>, IGetById<T> where T : BaseEntity
    {
        private readonly string _table;
        /// <param name="table">O nome da tabela do banco de dados ao qual o repositório está associado.</param>
        public BaseRepository(string table)
        {
            _table = table;
        }
        /// <summary>
        /// Remove a entidade com o id especificado do banco de dados.
        /// </summary>
        /// <param name="id">O id da entidade a ser removida.</param>
        public void Remove(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var affectedRows = connection.Execute($"DELETE FROM {_table} WHERE ID = '{id}'");
            }
        }
        /// <summary>
        /// Obtém todas as entidades do banco de dados como uma lista de objetos do tipo T.
        /// </summary>
        /// <returns>Uma lista de objetos do tipo T representando todas as entidades do banco de dados.</returns>
        public IEnumerable<T> GetAll()
        {

            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                return connection.Query<T>($"SELECT * FROM {_table.ToUpper()}");
            }
        }

        public T? GetById(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                return connection.QueryFirstOrDefault<T>($"SELECT * FROM {_table} WHERE ID = {id}");
            }
        }
    }
}