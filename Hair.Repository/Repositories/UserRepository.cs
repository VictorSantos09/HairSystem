using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso de usuarios da entidade <see cref="UserEntity"/>
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>, IBaseRepository<UserEntity>
    {
        public UserRepository() : base("USERS")
        {

        }
        public void Create(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO USERS (ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, ADDRESS, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE) VALUES ('{user.Id}', '{user.SaloonName}','{user.OwnerName}','{user.PhoneNumber}','{user.Email}','{user.Password}'," +
                    $"'{user.Adress}','{user.CNPJ}','{user.Haircutes}','{user.PriceEntity}')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }

        public void Update(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE USERS SET ID = {user.Id}, SALOON_NAME = {user.SaloonName}, OWNER_NAME = {user.SaloonName}, PHONE_NUMBER = {user.PhoneNumber}, EMAIL = {user.Email}, PASSWORD = {user.Password}," +
                    $" ADDRESS = {user.Adress}, CNPJ = {user.CNPJ}, HAIRCUT_TIME = {user.Haircutes}, HAIRCUT_PRICE='{user.PriceEntity}'");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}