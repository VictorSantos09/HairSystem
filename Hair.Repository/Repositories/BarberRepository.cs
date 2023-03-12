using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using Hair.Repository.Security;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade Barber contida em <see cref="BarberEntity"/>.
    /// </summary>
    public class BarberRepository : IBaseRepository<BarberEntity>
    {
        public void Create(BarberEntity barber)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spCreateBarber @ID, @NAME, @PHONE_NUMBER, @EMAIL, @SALARY, @HIRED, @SALOON_ID, @ADDRESS_FK," +
                    "@STREET, @NUMBER, @CITY, @STATE, @COMPLEMENT, @CEP", new
                {
                    ID = barber.Id,
                    NAME = CryptoSecurity.Encrypt(barber.Name),
                    PHONE_NUMBER = CryptoSecurity.Encrypt(barber.PhoneNumber),
                    EMAIL = CryptoSecurity.Encrypt(barber.Email),
                    SALARY = barber.Salary,
                    HIRED = barber.Hired,
                    SALOON_ID = barber.SaloonId,
                    ADDRESS_FK = barber.Address.Id,

                    STREET = barber.Address.Street,
                    NUMBER = barber.Address.Number,
                    CITY = barber.Address.City,
                    STATE = barber.Address.State,
                    COMPLEMENT = barber.Address.Complement,
                    CEP = barber.Address.CEP
                });
            }
        }

        public List<BarberEntity> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<BarberEntity>("dbo.").ToList();
            }
        }

        public BarberEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<BarberEntity>("dbo.", new { ID = id }).FirstOrDefault();   
            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo");

                return true;
            }
        }

        public void Update(BarberEntity barber)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo");
            }
        }
    }
}