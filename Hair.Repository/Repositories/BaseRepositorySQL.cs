using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Hair.Domain.Common;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;

namespace Hair.Repository.Repositories
{
    public class BaseRepositorySQL<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IDbConnection _connection;

        public BaseRepositorySQL(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Add(T entity)
        {
            _connection.Execute($"INSERT INTO {entity}");
        }

        public List<T> GetAll()
        {
            return _connection.Query<T>("SELECT * FROM USERS").ToList();
        }

        public T GetById(Guid id)
        {
            return _connection.QueryFirstOrDefault<T>("SELECT FROM USERS WHERE ID = @Id", new { id }); // Diante da não-referência do método, utilizei a tabela 'USERS' para teste.
        }

        public void Remove(Guid id)
        {
            _connection.Execute($"DELETE FROM USERS WHERE ID = {id}");
        }

        public void Update(Guid id, T newEntity)
        {
            _connection.Execute($"UPDATE {newEntity} WHERE ID ={id}");
        }
    }
 }