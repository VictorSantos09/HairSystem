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
    /// Classe responsável por implementar as operações de Create e Update de usuários no banco de dados contidos na <see cref="UserEntity"/>.
    /// </summary>
    public class UserRepository : IBaseRepository<UserEntity>, IGetByEmail
    {
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;
        private readonly IBaseRepository<HaircutPriceEntity> _priceRepository;
        private readonly IBaseRepository<AddressEntity> _addressRepository;

        public UserRepository(IBaseRepository<HaircutEntity> haircutRepository, IBaseRepository<HaircutPriceEntity> priceRepository, 
            IBaseRepository<AddressEntity> addressRepository)
        {
            _haircutRepository = haircutRepository;
            _priceRepository = priceRepository;
            _addressRepository = addressRepository;
        }

        public void Create(UserEntity user)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
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
                    GOOGLE_MAPS_SOURCE = user.GoogleMapsSource,
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
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spUpdateUser");
            }
        }

        public UserEntity? GetByEmail(string email, string password)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var userSql = conn.Query<UserEntityFromSql>("dbo.spGetUserByEmail @EMAIL, @PASSWORD", new
                {
                    EMAIL = CryptoSecurity.Encrypt(email.ToUpper()),
                    PASSWORD = CryptoSecurity.Encrypt(password)
                }).FirstOrDefault();

                if (userSql == null)
                    return null;

                var user = FillUser(userSql);
                PopulateExtraEntities(user);

                return user == null ? null : user;
            }
        }

        public UserEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = conn.Query<UserEntity>("dbo.spGetUserById @ID", new { ID = id }).FirstOrDefault();

                PopulateExtraEntities(user);

                return user == null ? null : user;
            }
        }

        public List<UserEntity> GetAll()
        {
            var output = new List<UserEntity>();
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var usersFromSql = conn.Query<UserEntityFromSql>("dbo.spGetAllUsers").ToList();

                output.AddRange(FillUser(usersFromSql));
            }
            return output;
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var user = GetById(id);

                conn.Query("dbo.spRemoveUser @ID", new { ID = id });

                foreach (var haircut in user.Haircuts)
                {
                    _haircutRepository.Remove(haircut.Id);
                }

                return true;
            }
        }

        private void PopulateExtraEntities(UserEntity user)
        {
            if (user == null)
                return;

            var haircuts = _haircutRepository.GetAll().FindAll(x => x.SaloonId == user.Id);
            var price = _priceRepository.GetById(user.Id);
            var address = _addressRepository.GetById(user.Id);

            user.Address = address;
            user.Prices = price;
            user.Haircuts.AddRange(haircuts);
        }

        private UserEntity DecryptProcess(UserEntityFromSql userSql)
        {
            var user = new UserEntity();

            user.Id = userSql.Id;
            user.Address = userSql.Address;
            user.SaloonName = userSql.Saloon_Name;
            user.GoogleMapsSource = userSql.Google_Maps_Source;
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
                PopulateExtraEntities(user);
                output.Add(user);
            }

            return output;
        }

        private UserEntity? FillUser(UserEntityFromSql userFromSql)
        {
            var user = DecryptProcess(userFromSql);

            return user == null ? null : user;
        }
    }
}