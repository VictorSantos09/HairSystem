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
    public class BarberRepository : BaseRepository<BarberEntity>, IBaseRepository<BarberEntity>
    {
        public static readonly string TableName = "BARBERS";
        public BarberRepository() : base(TableName)
        {
        }
        public void Create(BarberEntity barber)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO {TableName} (@ID, @NAME, @PHONENUMBER, @EMAIL, @SALARY, @HIRED, @ADDRESS, @JOBSALOON_ID, @JOBSALOON_NAME)");

                conn.Open();

                query.Parameters.AddWithValue("@ID", barber.Id);
                query.Parameters.AddWithValue("@NAME", barber.Name);
                query.Parameters.AddWithValue("@PHONENUMBER", barber.PhoneNumber);
                query.Parameters.AddWithValue("@EMAIL", barber.Email);
                query.Parameters.AddWithValue("@SALARY", barber.Salary);
                query.Parameters.AddWithValue("@HIRED", barber.Hired);
                query.Parameters.AddWithValue("ADDRESS", barber.Adress);
                query.Parameters.AddWithValue("@JOBSALOON_ID", barber.JobSaloonId);
                query.Parameters.AddWithValue("@JOBSALOON_NAME", barber.JobSaloonName);

                query.ExecuteNonQueryAsync();
            }
        }
        public void Update(BarberEntity barber)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE {TableName} SET NAME = {barber.Name}, PHONENUMBER = {barber.PhoneNumber} , EMAIL = {barber.Email} , SALARY = {barber.Salary} , HIRED = {barber.Hired}, ADDRESS = {barber.Adress}, " +
                    $"JOBSALOON_ID = {barber.JobSaloonId}, JOBSALOON_NAME = {barber.JobSaloonName} WHERE ID = {barber.Id} ");
                conn.Open();
            }
        }
    }
}
