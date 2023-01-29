using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositorio para acesso de usuarios da entidade <see cref="UserEntity"/>
    /// </summary>
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository() : base("USERS")
        {

        }

        public void Create(UserEntity user)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"INSERT INTO USERS (ID, SALOON_NAME, OWNER_NAME, PHONE_NUMBER, EMAIL, PASSWORD, ADDRESS, CNPJ, HAIRCUT_TIME, HAIRCUT_PRICE) 
                  VALUES (@Id, @SaloonName, @OwnerName, @PhoneNumber, @Email, @Password, @Address, @CNPJ, @PriceEntity)";
                //var affectedRows = connection.Execute();
            }
        }

        public UserEntity Read(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "SELECT * FROM USERS WHERE ID = @Id";
                return connection.QueryFirstOrDefault<UserEntity>(query, new { id });
            }
        }

        public void Update(UserEntity user)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = @"UPDATE Users SET SALOON_NAME = @SaloonName, OWNER_NAME = @OwnerName, PHONE_NUMBER = @PhoneNumber,
                            EMAIL = @Email, PASSWORD = @Password, ADDRESS = @Address, CNPJ = @CNPJ, HAIRCUT_TIME = @HaircuteTime, HAIRCUT_PRICE = @PriceEntity
                            WHERE Id = @Id";
                var affectedRows = connection.Execute(query, new
                {
                    user.SaloonName,
                    user.OwnerName,
                    user.PhoneNumber,
                    user.Email,
                    user.Password,
                    user.Adress,
                    user.CNPJ,
                    user.Haircutes, // ERRO, se tornou uma lista e no DB usa uma unica entidade
                    user.PriceEntity,
                    user.Id
                });
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "DELETE FROM USERS WHERE ID = @Id";
                var affectedRows = connection.Execute(query, new { id });
            }
        }

        public IEnumerable<UserEntity> GetAll()
        {
            using (var connection = new SqlConnection(DataAccess.DBConnection))
            {
                var query = "SELECT * FROM USERS";
                return connection.Query<UserEntity>(query);
            }
        }
    }
}