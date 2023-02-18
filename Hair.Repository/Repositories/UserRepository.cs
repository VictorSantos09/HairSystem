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
    public class UserRepository : BaseRepository<UserEntity>, IGetByEmail
    {
        private readonly static string TableName = "USERS";

        public UserRepository() : base(TableName)
        {

        }
        public void Create(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName} VALUES (@ID, @SALOON_NAME, @OWNER_NAME, @PHONE_NUMBER, @EMAIL," +
                    $" @PASSWORD, @CNPJ, @HAIRCUT_TIME, @HAIRCUT_PRICE)", conn);

                conn.Open();

                query.Parameters.AddWithValue("@ID", user.Id);
                query.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                query.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                query.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                query.Parameters.AddWithValue("@EMAIL", user.Email);
                query.Parameters.AddWithValue("@PASSWORD", user.Password);
                query.Parameters.AddWithValue("@CNPJ", user.CNPJ);
                query.Parameters.AddWithValue("@HAIRCUT_TIME", "02/04/2004"); // colocar como datetime ou string tanto no C# quanto SQL
                query.Parameters.AddWithValue("@HAIRCUT_PRICE", user.Prices.Hair); // Resolver questao de ser necessario dizer a propriedade. Ex: Prices.Hair, deve ser apenas user.Prices

                query.ExecuteNonQueryAsync();
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var output = conn.Query<UserEntity>($" SELECT * FROM {TableName} WHERE EMAIL = '{email.ToUpper()}' AND PASSWORD = '{password}'").ToList().First();
                return output;
            }
        }

        public void Update(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET SALOON_NAME = @SaloonName, OWNER_NAME = @OwnerName, PHONE_NUMBER = @PhoneNumber, EMAIL = @Email, " +
                    $"PASSWORD = @Password, CNPJ = @CNPJ, HAIRCUT_TIME = @HaircuteTime, HAIRCUT_PRICE = @Prices WHERE @ID = Id)");

                conn.Open();

                query.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                query.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                query.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                query.Parameters.AddWithValue("@EMAIL", user.Email);
                query.Parameters.AddWithValue("@PASSWORD", user.Password);
                query.Parameters.AddWithValue("@CNPJ", user.CNPJ);
                query.Parameters.AddWithValue("@HAIRCUT_TIME", "02/04/2004");
                query.Parameters.AddWithValue("@HAIRCUT_PRICE", user.Prices.Hair);
                query.Parameters.AddWithValue("@ID", user.Id);

                query.ExecuteNonQueryAsync();
            }
        }
    }
}