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
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : IApplicationDbContext<UserEntity>, IGetByEmailDbContext
    {
        public void Create(UserEntity user)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Execute("dbo.spCreateUser", new
                {

                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(UserEntity user)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateUser", new
                {

                });
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var userSql = conn.Query<UserEntityFromSql>("dbo.spGetUserByEmail @EMAIL, @PASSWORD", new
                {
                    EMAIL = CryptoSecurity.Encrypt(email.ToUpper()),
                    PASSWORD = CryptoSecurity.Encrypt(password)
                }).FirstOrDefault();

                if (userSql == null)
                    return null;

                var user = FillUser(userSql);

                return user == null ? null : user;
            }
        }

        public UserEntity? GetById(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var userSql = conn.Query<UserEntityFromSql>("dbo.spGetUserById @ID", new { ID = id }).FirstOrDefault();

                if (userSql == null)
                    return null;

                var user = FillUser(userSql);

                return user == null ? null : user;
            }
        }

        public List<UserEntity> GetAll()
        {
            var output = new List<UserEntity>();
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var usersFromSql = conn.Query<UserEntityFromSql>("dbo.spGetAllUsers").ToList();

                output.AddRange(FillUser(usersFromSql));
            }
            return output;
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var user = GetById(id);

                conn.Query("dbo.spDeleteUser @ID", new { ID = id });

            }
            return true;
        }

        private UserEntity DecryptProcess(UserEntityFromSql userSql)
        {
            var user = new UserEntity();

            user.Id = userSql.Id;
            user.Address = userSql.Address;
            user.SaloonName = userSql.Saloon_Name;
            user.GoogleMapsLocation = userSql.Google_Maps_Source;
            user.CNPJ = userSql.CNPJ == null ? null : CryptoSecurity.Decrypt(userSql.CNPJ);
            user.Password = CryptoSecurity.Decrypt(userSql.Password);
            user.Email = CryptoSecurity.Decrypt(userSql.Email);
            user.PhoneNumber = CryptoSecurity.Decrypt(userSql.Phone_Number);
            user.OwnerName = CryptoSecurity.Decrypt(userSql.Owner_Name);

            return user;
        }

        private List<UserEntity>? FillUser(List<UserEntityFromSql> usersFromSql)
        {
            var output = new List<UserEntity>();

            foreach (var userSql in usersFromSql)
            {
                var user = DecryptProcess(userSql);
                output.Add(user);
            }

            return output;
        }

        private UserEntity? FillUser(UserEntityFromSql userFromSql)
        {
            var user = DecryptProcess(userFromSql);

            return user == null ? null : user;
        }

        private AddressEntity ConvertAddress(AddressEntityFromSql addressSql)
        {
            return new AddressEntity(addressSql.Street, addressSql.Number, addressSql.City, addressSql.State, addressSql.Complement, addressSql.CEP, addressSql.Id);
        }

    }
}