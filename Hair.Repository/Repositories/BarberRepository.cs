using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using System.Threading;
using Dapper;

namespace Hair.Repository.Repositories
{
    public class BarberRepository : BaseRepository<BarberEntity>
    {
        public BarberRepository() : base("BARBERS")
        {
        }

        public void Create(BarberEntity barber)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"INSERT INTO BARBERS (ID, NAME, PHONENUMBER, EMAIL, SALARY, HIRED, ADDRESS, JOBSALOON_ID, JOBSALOON_NAME) 
                  VALUES (@Id, @Name, @PhoneNumber, @Email, @Salary, @Street, @Number, @Complement, @City, @State, @Hired, @JobSaloonId, @JobSaloonName)";
                var affectedRows = connection.Execute(query, new
                {
                    barber.Id,
                    barber.Name,
                    barber.PhoneNumber,
                    barber.Email,
                    barber.Salary,
                    barber.Adress.Street,
                    barber.Adress.Number,
                    barber.Adress.Complement,
                    barber.Adress.City,
                    barber.Adress.State,
                    barber.Hired,
                    barber.JobSaloonId,
                    barber.JobSaloonName
                });
            }
        }

        public void Read(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "SELECT * FROM BARBERS WHERE ID = @Id";
                var barber = connection.QueryFirstOrDefault<BarberEntity>(query, new { id });
                var address = new AddressEntity(barber.Adress.Street, barber.Adress.Number, barber.Adress.Complement, barber.Adress.City, barber.Adress.State);
                barber.Adress = address;
            }
        }

        public void Update(BarberEntity barber)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"UPDATE BARBERS SET NAME = @Name, PHONENUMBER = @PhoneNumber, EMAIL = @Email, SALARY = @Salary,
                 Street = @Street, Number = @Number, Complement = @Complement, City = @City, State = @State,
                 HIRED = @Hired, JOBSALOON_ID = @JobSaloonId, JOBSALOON_NAME = @JobSaloonName
                  WHERE ID = @Id";
                var affectedRows = connection.Execute(query, new
                {
                    barber.Name,
                    barber.PhoneNumber,
                    barber.Email,
                    barber.Salary,
                    barber.Adress.Street,
                    barber.Adress.Number,
                    barber.Adress.Complement,
                    barber.Adress.City,
                    barber.Adress.State,
                    barber.Hired,
                    barber.JobSaloonId,
                    barber.JobSaloonName,
                    barber.Id
                });
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "DELETE FROM BARBERS WHERE Id = @Id";
                var affectedRows = connection.Execute(query, new { id });
            }

        }


    }

}
