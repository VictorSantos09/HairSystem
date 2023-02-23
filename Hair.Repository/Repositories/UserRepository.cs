using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : IBaseRepository<UserEntity>, IGetByEmail
    {
        private readonly static string TableName = "USERS";
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        public UserRepository(IBaseRepository<HaircutEntity> haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public void Create(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO {TableName} VALUES (@ID, @SALOON_NAME, @OWNER_NAME, @PHONE_NUMBER, @EMAIL," +
                    $" @PASSWORD, @CNPJ, @HAIRCUT_HAIR, @HAIRCUT_BEARD, @HAIRCUT_MUSTACHE)", conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@ID", user.Id);
                cmd.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                cmd.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@EMAIL", user.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", user.Password);
                cmd.Parameters.AddWithValue("@CNPJ", user.CNPJ);
                cmd.Parameters.AddWithValue("@HAIRCUT_HAIR", user.Prices.Hair);
                cmd.Parameters.AddWithValue("@HAIRCUT_BEARD", user.Prices.Beard);
                cmd.Parameters.AddWithValue("@HAIRCUT_MUSTACHE", user.Prices.Mustache);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"UPDATE {TableName} SET SALOON_NAME= @SALOON_NAME, OWNER_NAME= @OWNER_NAME, PHONE_NUMBER= @PHONE_NUMBER, EMAIL= @EMAIL," +
                    $" PASSWORD= @PASSWORD, CNPJ= @CNPJ, HAIRCUT_HAIR= @HAIRCUT_HAIR, HAIRCUT_MUSTACHE= @HAIRCUT_MUSTACHE, HAIRCUT_BEARD= @HAIRCUT_BEARD WHERE ID= @ID)";

                var cmd = new SqlCommand(query, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                cmd.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@EMAIL", user.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", user.Password);
                cmd.Parameters.AddWithValue("@CNPJ", user.CNPJ);
                cmd.Parameters.AddWithValue("@HAIRCUT_HAIR", user.Prices.Hair);
                cmd.Parameters.AddWithValue("@HAIRCUT_MUSTACHE", user.Prices.Mustache);
                cmd.Parameters.AddWithValue("@HAIRCUT_BEARD", user.Prices.Beard);
                cmd.Parameters.AddWithValue("@ID", user.Id);

                cmd.ExecuteNonQuery();
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

        public bool Remove(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"DELETE FROM {TableName} WHERE ID= @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();

                var user = GetById(id);

                var affectRows = cmd.ExecuteNonQuery();

                if (affectRows == 0)
                    return false;

                foreach (var haircut in user.Haircuts)
                {
                    _haircutRepository.Remove(haircut.Id);
                }

                return true;
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