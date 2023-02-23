using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Principal;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>, IGetByEmail
    {
        private readonly static string TableName = "USERS";
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        public UserRepository(IBaseRepository<HaircutEntity> haircutRepository) : base(TableName)
        {
            _haircutRepository = haircutRepository;
        }

        public void Create(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName} VALUES (@ID, @SALOON_NAME, @OWNER_NAME, @PHONE_NUMBER, @EMAIL," +
                    $" @PASSWORD, @CNPJ, @HAIRCUT_HAIR, @HAIRCUT_BEARD, @HAIRCUT_MUSTACHE)", conn);

                conn.Open();

                query.Parameters.AddWithValue("@ID", user.Id);
                query.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                query.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                query.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                query.Parameters.AddWithValue("@EMAIL", user.Email);
                query.Parameters.AddWithValue("@PASSWORD", user.Password);
                query.Parameters.AddWithValue("@CNPJ", user.CNPJ);
                query.Parameters.AddWithValue("@HAIRCUT_HAIR", user.Prices.Hair);
                query.Parameters.AddWithValue("@HAIRCUT_BEARD", user.Prices.Beard);
                query.Parameters.AddWithValue("@HAIRCUT_MUSTACHE", user.Prices.Mustache);

                query.ExecuteNonQuery();
            }
        }
        public void Update(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET SALOON_NAME = @SaloonName, OWNER_NAME = @OwnerName, PHONE_NUMBER = @PhoneNumber, EMAIL = @Email, " +
                    $"PASSWORD = @Password, CNPJ = @CNPJ, HAIRCUT_PRICE = @Prices WHERE @ID = Id)");

                conn.Open();

                query.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                query.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                query.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                query.Parameters.AddWithValue("@EMAIL", user.Email);
                query.Parameters.AddWithValue("@PASSWORD", user.Password);
                query.Parameters.AddWithValue("@CNPJ", user.CNPJ);
                query.Parameters.AddWithValue("@HAIRCUT_PRICE", user.Prices.Hair);
                query.Parameters.AddWithValue("@ID", user.Id);

                query.ExecuteNonQuery();
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $" SELECT * FROM {TableName} WHERE EMAIL= @EMAIL AND PASSWORD= @PASSWORD";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@EMAIL", email.ToUpper());
                cmd.Parameters.AddWithValue("@PASSWORD", password);

                conn.Open();

                return BuildEntity(cmd);
            }
        }

        public UserEntity? GetById(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName} WHERE Id= @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                return BuildEntity(cmd);
            }
        }

        public List<UserEntity> GetAll()
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var users = new List<UserEntity>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserEntity();

                        user.Id = reader.GetGuid("ID");
                        user.Password = reader.GetString("PASSWORD");
                        user.CNPJ = reader.GetString("CNPJ");
                        user.Email = reader.GetString("EMAIL");
                        user.OwnerName = reader.GetString("OWNER_NAME");
                        user.PhoneNumber = reader.GetString("PHONE_NUMBER");
                        user.SaloonName = reader.GetString("SALOON_NAME");
                        user.Prices.Hair = reader.GetDouble("HAIRCUT_HAIR");
                        user.Prices.Mustache = reader.GetDouble("HAIRCUT_MUSTACHE");
                        user.Prices.Beard = reader.GetDouble("HAIRCUT_BEARD");

                        PopulateHaircut(user);

                        users.Add(user);
                    }
                }
                return users;
            }
        }

        private UserEntity? BuildEntity(SqlCommand cmd)
        {
            var user = new UserEntity();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.Id = reader.GetGuid("ID");
                    user.Password = reader.GetString("PASSWORD");
                    user.CNPJ = reader.GetString("CNPJ");
                    user.Email = reader.GetString("EMAIL");
                    user.OwnerName = reader.GetString("OWNER_NAME");
                    user.PhoneNumber = reader.GetString("PHONE_NUMBER");
                    user.SaloonName = reader.GetString("SALOON_NAME");
                    user.Prices.Hair = reader.GetDouble("HAIRCUT_HAIR");
                    user.Prices.Mustache = reader.GetDouble("HAIRCUT_MUSTACHE");
                    user.Prices.Beard = reader.GetDouble("HAIRCUT_BEARD");

                }
            }

            PopulateHaircut(user);
            return user;
        }
        private void PopulateHaircut(UserEntity user)
        {
            var haircuts = _haircutRepository.GetAll().FindAll(x => x.SaloonId == user.Id);

            user.Haircuts.AddRange(haircuts);
        }
    }
}