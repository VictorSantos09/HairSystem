using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.EntitiesSql;
using Hair.Repository.Interfaces;
using Hair.Repository.Security;
using System.Data;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade Barber contida em <see cref="BarberEntity"/>.
    /// </summary>
    public class BarberRepository : IBaseRepository<BarberEntity>
    {
        public void Create(BarberEntity barber)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
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
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return conn.Query<BarberEntity>("dbo.spGetAllBarbers").ToList();
            }
        }

        public BarberEntity? GetById(Guid id)
        {
            var output = new BarberEntity();
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var barberSql = conn.Query<BarberEntityFromSql>("dbo.spGetBarberById", new { ID = id }).FirstOrDefault();
                var barberAddress = ConvertAddress(conn.Query<AddressEntityFromSql>("dbo.spGetBarberAddress", new { ID = id }).FirstOrDefault());

                output.PhoneNumber = barberSql.Phone_Number;
                output.Id = barberSql.Id;
                output.Address = barberAddress;
                output.Email = barberSql.Email;
                output.Name = barberSql.Name;
                output.SaloonName = barberSql.Saloon_Name;
                output.SaloonId = barberSql.Saloon_Id;
                output.Salary = barberSql.Salary;
                output.Hired = barberSql.Hired;

            }
            return output;
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spDeleteBarber");

                return true;
            }
        }

        public void Update(BarberEntity barber)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateBarber @ID, @NAME, @PHONE_NUMBER, @EMAIL, @SALARY, @HIRED, @SALOON_ID, @ADDRESS_FK," +
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

        private AddressEntity ConvertAddress(AddressEntityFromSql addressSql)
        {
            return new AddressEntity(addressSql.Street, addressSql.Number, addressSql.City, addressSql.State, addressSql.Complement, addressSql.CEP, addressSql.Id);
        }
    }
}