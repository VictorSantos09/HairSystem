using Dapper;
using Hair.Domain.Common;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Base Principal dos repositorios onde efetua a ação escolhida, contendo as funções implementadas da interface <see cref="IBaseRepository{T}"/>
    /// Todos os repositories existente DEVEM herdar dessa classe.
    /// </summary>

    public abstract class BaseRepository<T> : IRemove, IGetAll<T>, IGetById<T> where T : BaseEntity
    {
        private readonly string _table;
        public BaseRepository(string table)
        {
            _table = table;
        }

        public void Remove(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var affectedRows = connection.Execute($"DELETE FROM {_table} WHERE ID = '{id}'");
            }
        }

        public List<T> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(DataAccess.DBConnection))
            {
                var output = connection.Query<T>($"SELECT * FROM {_table}").ToList();
                return output;
            }
        }

        public T? GetById(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var output = connection.QueryFirstOrDefault<T>($"SELECT * FROM {_table} WHERE ID = '{id}'");
                return output;
            }
        }
    }
}