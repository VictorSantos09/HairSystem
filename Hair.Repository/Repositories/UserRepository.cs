using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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
                    $" @PASSWORD, @CNPJ, @HAIRCUT_HAIR, @HAIRCUT_BEARD, @HAIRCUT_MUSTACHE, @OPEN_TIME, @GOOGLE_MAPS_SOURCE, @CLOSE_TIME, " +
                    $"@STREET, @STATE, @CITY, @COMPLEMENT, @NUMBER, @FULL_ADDRESS)", conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@ID", user.Id);
                cmd.Parameters.AddWithValue("@SALOON_NAME", user.SaloonName);
                cmd.Parameters.AddWithValue("@OWNER_NAME", user.OwnerName);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", user.PhoneNumber);
                cmd.Parameters.AddWithValue("@EMAIL", user.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", user.Password);
                cmd.Parameters.AddWithValue("@CNPJ", user.CNPJ == null ? SqlString.Null : user.CNPJ);
                cmd.Parameters.AddWithValue("@HAIRCUT_HAIR", user.Prices.Hair);
                cmd.Parameters.AddWithValue("@HAIRCUT_BEARD", user.Prices.Beard);
                cmd.Parameters.AddWithValue("@HAIRCUT_MUSTACHE", user.Prices.Mustache);
                cmd.Parameters.AddWithValue("@OPEN_TIME", user.OpenTime);
                cmd.Parameters.AddWithValue("@GOOGLE_MAPS_SOURCE", user.GoogleMapsSource == null ? SqlString.Null : user.GoogleMapsSource);
                cmd.Parameters.AddWithValue("@CLOSE_TIME", user.CloseTime);
                cmd.Parameters.AddWithValue("@STREET", user.Address.Street);
                cmd.Parameters.AddWithValue("@STATE", user.Address.State);
                cmd.Parameters.AddWithValue("@CITY", user.Address.City);
                cmd.Parameters.AddWithValue("@COMPLEMENT", user.Address.Complement == null ? SqlString.Null : user.Address.Complement);
                cmd.Parameters.AddWithValue("@NUMBER", user.Address.Number);
                cmd.Parameters.AddWithValue("@FULL_ADDRESS", user.Address.FullAddress);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(UserEntity user)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {

                var query = $"UPDATE {TableName} SET SALOON_NAME = @SALOON_NAME, OWNER_NAME = @OWNER_NAME, PHONE_NUMBER = @PHONE_NUMBER, " +
                    $"EMAIL = @EMAIL, PASSWORD = @PASSWORD, CNPJ = @CNPJ, HAIRCUT_HAIR = @HAIRCUT_HAIR, HAIRCUT_BEARD = @HAIRCUT_BEARD, " +
                    $"HAIRCUT_MUSTACHE = @HAIRCUT_MUSTACHE, OPEN_TIME = @OPEN_TIME, GOOGLE_MAPS_SOURCE = @GOOGLE_MAPS_SOURCE, CLOSE_TIME = @CLOSE_TIME, " +
                    $"STREET = @STREET, STATE = @STATE, CITY = @CITY, COMPLEMENT = @COMPLEMENT, NUMBER = @NUMBER, FULL_ADDRESS = @FULL_ADDRESS " +
                    $"WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

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
                cmd.Parameters.AddWithValue("@OPEN_TIME", user.OpenTime);
                cmd.Parameters.AddWithValue("@GOOGLE_MAPS_SOURCE", user.GoogleMapsSource);
                cmd.Parameters.AddWithValue("@CLOSE_TIME", user.CloseTime);
                cmd.Parameters.AddWithValue("@STREET", user.Address.Street);
                cmd.Parameters.AddWithValue("@STATE", user.Address.State);
                cmd.Parameters.AddWithValue("@CITY", user.Address.City);
                cmd.Parameters.AddWithValue("@COMPLEMENT", user.Address.Complement);
                cmd.Parameters.AddWithValue("@NUMBER", user.Address.Number);
                cmd.Parameters.AddWithValue("@FULL_ADDRESS", user.Address.FullAddress);

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

                return BuildEntity(cmd.ExecuteReader());
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

                return BuildEntity(cmd.ExecuteReader());
            }
        }

        public List<UserEntity> GetAll()
        {
            var output = new List<UserEntity>();
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = BuildEntity(reader);
                        output.Add(user);
                    }
                }
            }
            return output;
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

        private UserEntity BuildEntity(SqlDataReader reader)
        {
            var user = new UserEntity();
            user.Id = reader.GetGuid("ID");
            user.Password = reader.GetString("PASSWORD");
            user.CNPJ = reader.IsDBNull("CNPJ") ? null : reader.GetString("CNPJ");
            user.Email = reader.GetString("EMAIL");
            user.OwnerName = reader.GetString("OWNER_NAME");
            user.PhoneNumber = reader.GetString("PHONE_NUMBER");
            user.SaloonName = reader.GetString("SALOON_NAME");
            user.Prices.Hair = reader.GetDouble("HAIRCUT_HAIR");
            user.Prices.Mustache = reader.GetDouble("HAIRCUT_MUSTACHE");
            user.Prices.Beard = reader.GetDouble("HAIRCUT_BEARD");
            user.OpenTime = DateTime.Parse(reader.GetTimeSpan(10).ToString());
            user.CloseTime = DateTime.Parse(reader.GetTimeSpan(12).ToString());
            user.Address.Street = reader.GetString("STREET");
            user.Address.State = reader.GetString("STATE");
            user.Address.City = reader.GetString("CITY");
            user.Address.Complement = reader.IsDBNull("COMPLEMENT") ? null : reader.GetString("COMPLEMENT");
            user.Address.Number = reader.GetString("NUMBER");
            user.Address.FullAddress = reader.GetString("FULL_ADDRESS");
            user.GoogleMapsSource = reader.IsDBNull("GOOGLE_MAPS_SOURCE") ? null : reader.GetString("GOOGLE_MAPS_SOURCE");

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