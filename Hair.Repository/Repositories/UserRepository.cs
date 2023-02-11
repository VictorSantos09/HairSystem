using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>, IGetByEmail, IBaseRepository<UserEntity>
    {
        private static string TableName { get; } = "USERS";
        private List<UserEntity> _users { get; set; } = new();

        public UserRepository() : base(TableName)
        {

        }
        public void Create(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                _users.Add(user);

                conn.Execute($"INSERT INTO {TableName}",_users);
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var output = conn.Query<UserEntity>($"SELECT * FROM {TableName} WHERE EMAIL = '{email}' AND PASSWORD = '{password}'").ToList().First();

                return output;
            }
        }

        public void Update(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Execute($"UPDATE {TableName}", user);
            }
        }
    }
}