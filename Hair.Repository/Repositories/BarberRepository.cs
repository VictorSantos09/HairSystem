using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade Barber contida em <see cref="BarberEntity"/>.
    /// </summary>
    public class BarberRepository : IBaseRepository<BarberEntity>
    {
        public static readonly string TableName = "BARBERS";
        public void Create(BarberEntity barber)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO {TableName} VALUES (@ID, @NAME, @PHONE_NUMBER, @EMAIL, @SALARY, @HIRED, " +
                    $"@STREET, @STATE, @CITY, @COMPLEMENT, @NUMBER, @FULL_ADDRESS, @SALOON_ID, @SALOON_NAME)", conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@ID", barber.Id);
                cmd.Parameters.AddWithValue("@NAME", barber.Name);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", barber.PhoneNumber);
                cmd.Parameters.AddWithValue("@EMAIL", barber.Email);
                cmd.Parameters.AddWithValue("@SALARY", barber.Salary);
                cmd.Parameters.AddWithValue("@HIRED", barber.Hired);
                cmd.Parameters.AddWithValue("@STREET", barber.Address.Street);
                cmd.Parameters.AddWithValue("@STATE", barber.Address.State);
                cmd.Parameters.AddWithValue("@CITY", barber.Address.City);
                cmd.Parameters.AddWithValue("@COMPLEMENT", barber.Address.Complement);
                cmd.Parameters.AddWithValue("@NUMBER", barber.Address.Number);
                cmd.Parameters.AddWithValue("@FULL_ADDRESS", barber.Address.FullAddress);
                cmd.Parameters.AddWithValue("@SALOON_ID", barber.SaloonId);
                cmd.Parameters.AddWithValue("@SALOON_NAME", barber.SaloonName);

                cmd.ExecuteNonQuery();
            }
        }

        public List<BarberEntity> GetAll()
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"SELECT * FROM {TableName}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                var barbers = new List<BarberEntity>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var barber = new BarberEntity();

                    barber.Id = reader.GetGuid("ID");
                    barber.Name = reader.GetString("NAME");
                    barber.PhoneNumber = reader.GetString("PHONE_NUMBER");
                    barber.Email = reader.GetString("EMAIL");
                    barber.Salary = reader.GetDouble("SALARY");
                    barber.Hired = reader.GetBoolean("HIRED");
                    barber.Address.Street = reader.GetString("STREET");
                    barber.Address.State = reader.GetString("STATE");
                    barber.Address.City = reader.GetString("CITY");
                    barber.Address.Complement = reader.GetString("COMPLEMENT");
                    barber.Address.Number = reader.GetString("NUMBER");
                    barber.Address.FullAddress = reader.GetString("FULL_ADDRESS");
                    barber.SaloonId = reader.GetGuid("SALOON_ID");
                    barber.SaloonName = reader.GetString("SALOON_NAME");

                    barbers.Add(barber);
                }

                return barbers;
            }
        }

        public BarberEntity? GetById(Guid id)
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

        public bool Remove(Guid id)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"DELETE FROM {TableName} WHERE ID= @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();

                var affectRows = cmd.ExecuteNonQuery();

                if (affectRows == 0)
                    return false;

                return true;
            }
        }

        public void Update(BarberEntity barber)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"UPDATE {TableName} SET " +
                    $"NAME = @NAME, " +
                    $"PHONE_NUMBER = @PHONE_NUMBER, " +
                    $"EMAIL = @EMAIL, " +
                    $"SALARY = @SALARY, " +
                    $"HIRED = @HIRED, " +
                    $"STREET = @STREET, " +
                    $"STATE = @STATE, " +
                    $"CITY = @CITY, " +
                    $"COMPLEMENT = @COMPLEMENT, " +
                    $"NUMBER = @NUMBER, " +
                    $"FULL_ADDRESS = @FULL_ADDRESS, " +
                    $"SALOON_ID = @SALOON_ID, " +
                    $"SALOON_NAME = @SALOON_NAME " +
                    $"WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@ID", barber.Id);
                cmd.Parameters.AddWithValue("@NAME", barber.Name);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", barber.PhoneNumber);
                cmd.Parameters.AddWithValue("@EMAIL", barber.Email);
                cmd.Parameters.AddWithValue("@SALARY", barber.Salary);
                cmd.Parameters.AddWithValue("@HIRED", barber.Hired);
                cmd.Parameters.AddWithValue("@STREET", barber.Address.Street);
                cmd.Parameters.AddWithValue("@STATE", barber.Address.State);
                cmd.Parameters.AddWithValue("@CITY", barber.Address.City);
                cmd.Parameters.AddWithValue("@COMPLEMENT", barber.Address.Complement);
                cmd.Parameters.AddWithValue("@NUMBER", barber.Address.Number);
                cmd.Parameters.AddWithValue("@FULL_ADDRESS", barber.Address.FullAddress);
                cmd.Parameters.AddWithValue("@SALOON_ID", barber.SaloonId);
                cmd.Parameters.AddWithValue("@SALOON_NAME", barber.SaloonName);

                cmd.ExecuteNonQuery();
            }
        }

        private BarberEntity? BuildEntity(SqlDataReader reader)
        {
            BarberEntity? barber = new BarberEntity();

            while (reader.Read())
            {
                barber.Id = reader.GetGuid("ID");
                barber.Name = reader.GetString("NAME");
                barber.PhoneNumber = reader.GetString("PHONE_NUMBER");
                barber.Email = reader.GetString("EMAIL");
                barber.Salary = reader.GetDouble("SALARY");
                barber.Hired = reader.GetBoolean("HIRED");
                barber.Address.Street = reader.GetString("STREET");
                barber.Address.State = reader.GetString("STATE");
                barber.Address.City = reader.GetString("CITY");
                barber.Address.Complement = reader.GetString("COMPLEMENT");
                barber.Address.Number = reader.GetString("NUMBER");
                barber.Address.FullAddress = reader.GetString("FULL_ADDRESS");
                barber.SaloonId = reader.GetGuid("SALOON_ID");
                barber.SaloonName = reader.GetString("SALOON_NAME");
            }

            return barber.Id == Guid.Empty ? null : barber;
        }
    }
}