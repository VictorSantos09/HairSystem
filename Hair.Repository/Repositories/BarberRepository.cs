using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using System.Threading;
using Dapper;
using Hair.Repository.Interfaces;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade Barber contida em <see cref="BarberEntity"/>.
    /// </summary>
    public class BarberRepository : BaseRepository<BarberEntity>, IBaseRepository<BarberEntity>
    {


        public BarberRepository() : base("BARBERS")
        {
        }
        public void Create(BarberEntity barber)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"INSERT INTO HAIRCUTS (ID, NAME, PHONENUMBER, EMAIL, SALARY, HIRED, ADDRESS, JOBSALOON_ID, JOBSALOON_NAME) VALUES ('{barber.Id}', '{barber.Name}','{barber.PhoneNumber}','{barber.Email}','{barber.Salary}','{barber.Hired}'," +
                    $"'{barber.Adress}','{barber.JobSaloonId}','{barber.JobSaloonName}',')", conn);
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
        public void Update(BarberEntity barber)
        {
            using (var conn = new SqlConnection(DataAccess.DBConnection))
            {
                var query = new SqlCommand($"UPDATE HAIRCUTS SET ID = {barber.Id}, NAME = {barber.Name}, PHONENUMBER = {barber.PhoneNumber} , EMAIL = {barber.Email} , SALARY = {barber.Salary} , HIRED = {barber.Hired}, ADDRESS = {barber.Adress}, " +
                    $"JOBSALOON_ID = {barber.JobSaloonId}, JOBSALOON_NAME = {barber.JobSaloonName} ");
                conn.Open();
                query.ExecuteNonQuery();
            }
        }
    }
}
