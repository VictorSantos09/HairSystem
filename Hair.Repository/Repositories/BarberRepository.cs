using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade Barber contida em <see cref="BarberEntity"/>.
    /// </summary>
    public class BarberRepository : IBaseRepository<IBarber>
    {
        public static readonly string TableName = "BARBERS";
        public void Create(IBarber barber)
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

        public List<IBarber> GetAll()
        {
            throw new NotImplementedException();
        }

        public IBarber? GetById(Guid id)
        {
            throw new NotImplementedException();
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

        public void Update(IBarber barber)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = $"UPDATE {TableName} SET NAME= @NAME, PHONE_NUMBER= @PHONE_NUMBER, EMAIL= @EMAIL, SALARY= @SALARY, " +
                    $"HIRED= @HIRED, JOB_SALOON_ID= @JOB_SALOON_ID, JOB_SALOON_NAME= @JOB_SALOON_NAME, " +
                    $"STREET= @STREET, STATE= @STATE, CITY= @CITY, COMPLEMENT= @COMPLEMENT, NUMBER= @NUMBER, FULL_ADDRESS= @FULL_ADDRESS WHERE ID= @ID";

                var cmd = new SqlCommand(query, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@NAME", barber.Name);
                cmd.Parameters.AddWithValue("@PHONE_NUMBER", barber.PhoneNumber);
                cmd.Parameters.AddWithValue("@EMAIL", barber.Email);
                cmd.Parameters.AddWithValue("@SALARY", barber.Salary);
                cmd.Parameters.AddWithValue("@HIRED", barber.Hired);
                cmd.Parameters.AddWithValue("@JOB_SALOON_ID", barber.SaloonId);
                cmd.Parameters.AddWithValue("@JOB_SALOON_NAME", barber.SaloonName);
                cmd.Parameters.AddWithValue("@ID", barber.Id);
                cmd.Parameters.AddWithValue("@STREET", barber.Address.Street);
                cmd.Parameters.AddWithValue("@STATE", barber.Address.State);
                cmd.Parameters.AddWithValue("@COMPLEMENT", barber.Address.Complement);
                cmd.Parameters.AddWithValue("@CITY", barber.Address.City);
                cmd.Parameters.AddWithValue("@NUMBER", barber.Address.Number);
                cmd.Parameters.AddWithValue("@FULL_ADDRESS", barber.Address.FullAddress);

                cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
