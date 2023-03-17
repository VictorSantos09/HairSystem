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
    public class UserRepository : IBaseRepository<UserEntity>, IGetByEmail
    {
        public void Create(UserEntity user)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Execute("dbo.spCreateUser", new
                {
                    ID = user.Id,
                    SALOON_NAME = user.SaloonName,
                    OWNER_NAME = CryptoSecurity.Encrypt(user.OwnerName),
                    PHONE_NUMBER = CryptoSecurity.Encrypt(user.PhoneNumber),
                    EMAIL = CryptoSecurity.Encrypt(user.Email),
                    PASSWORD = CryptoSecurity.Encrypt(user.Password),
                    CNPJ = user.CNPJ == null ? null : CryptoSecurity.Encrypt(user.CNPJ),
                    OPEN_TIME = user.OpenTime.ToString(),
                    GOOGLE_MAPS_SOURCE = user.GoogleMapsLocation,
                    CLOSE_TIME = user.CloseTime.ToString(),
                    STREET = user.Address.Street,
                    NUMBER = user.Address.Number,
                    CITY = user.Address.City,
                    STATE = user.Address.State,
                    COMPLEMENT = user.Address.Complement == null ? null : user.Address.Complement,
                    CEP = user.Address.CEP,
                    HAIR = user.Prices.Hair,
                    BEARD = user.Prices.Beard,
                    MUSTACHE = user.Prices.Mustache,
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(UserEntity user)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spUpdateUser", new
                {
                    ID = user.Id,
                    SALOON_NAME = CryptoSecurity.Encrypt(user.SaloonName),
                    OWNER_NAME = CryptoSecurity.Encrypt(user.OwnerName),
                    PHONE_NUMBER = CryptoSecurity.Encrypt(user.PhoneNumber),
                    EMAIL = CryptoSecurity.Encrypt(user.Email),
                    PASSWORD = CryptoSecurity.Encrypt(user.Password),
                    CNPJ = user.CNPJ == null ? null : CryptoSecurity.Encrypt(user.CNPJ),
                    OPEN_TIME = user.OpenTime,
                    GOOGLE_MAPS_SOURCE = user.GoogleMapsLocation,
                    CLOSE_TIME = user.CloseTime,

                    STREET = user.Address.Street,
                    NUMBER = user.Address.Number,
                    CITY = user.Address.City,
                    STATE = user.Address.State,
                    COMPLEMENT = user.Address.Complement,
                    CEP = user.Address.CEP,

                    HAIR = user.Prices.Hair,
                    BEARD = user.Prices.Beard,
                    MUSTACHE = user.Prices.Mustache
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
                PopulateExtraEntities(user, conn);

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
                PopulateExtraEntities(user, conn);

                return user == null ? null : user;
            }
        }

        public List<UserEntity> GetAll()
        {
            var output = new List<UserEntity>();
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var usersFromSql = conn.Query<UserEntityFromSql>("dbo.spGetAllUsers").ToList();

                output.AddRange(FillUser(usersFromSql, conn));
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

        private void PopulateExtraEntities(UserEntity user, IDbConnection conn)
        {
            if (user == null)
                return;

            var haircuts = conn.Query<DutyEntity>("dbo.spGetUserHaircuts @ID", new { ID = user.Id }).ToList();
            user.Address = ConvertAddress(conn.Query<AddressEntityFromSql>("dbo.spGetUserAddress @ID", new { ID = user.Id }).FirstOrDefault());
            user.Prices = conn.Query<HaircutPriceEntity>("spGetUserHaircutPrice @ID", new { ID = user.Id }).FirstOrDefault();

            user.Haircuts.AddRange(haircuts);
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

        private List<UserEntity>? FillUser(List<UserEntityFromSql> usersFromSql, IDbConnection conn)
        {
            var output = new List<UserEntity>();

            foreach (var userSql in usersFromSql)
            {
                var user = DecryptProcess(userSql);
                PopulateExtraEntities(user, conn);
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