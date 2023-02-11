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
        private readonly static string TableName = "USERS";

        public UserRepository() : base(TableName)
        {

        }
        public void Create(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName} (ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE) VALUES ('{user.Id}', '{user.SaloonName}','{user.OwnerName}','{user.PhoneNumber}','{user.Email}','{user.Password}', '{user.CNPJ}', 02/02/2004 ,'{user.Prices.Hair}')", conn);
                conn.Open();
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var output = conn.Query<UserEntity>($" SELECT * FROM {TableName} WHERE EMAIL = '{email}' AND PASSWORD = '{password}'").ToList().First();
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