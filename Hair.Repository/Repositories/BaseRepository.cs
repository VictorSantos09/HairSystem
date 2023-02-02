using Dapper;
using Hair.Domain.Common;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Base Principal dos repositorios onde efetua a ação escolhida, contendo as funções implementadas da interface <see cref="IBaseRepository{T}"/>
    /// Todos os repositories existente DEVEM herdar dessa classe.
    /// table: parâmetro de tabela passado no construtor que é usado como o nome da tabela no banco de dados com a qual interagir.
    /// Os métodos Remove, GetAll e GetById interagem com um banco de dados usando o DBConnection da classe DataAccess. 
    /// O método Remove executa uma instrução DELETE para remover uma entidade com um Id especificado.
    /// O método GetAll executa uma instrução SELECT para recuperar todas as entidades da tabela.
    /// O método GetById executa uma instrução SELECT para recuperar uma única entidade com um Id especificado. 


    public class BaseRepository<T> : IRemove, IGetAll<T>, IGetById<T> where T : BaseEntity
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