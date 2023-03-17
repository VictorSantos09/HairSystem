using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using Hair.Repository.Security;
using System.Data;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="DutyEntity"/>.
    /// </summary>
    public class HaircutRepository : IBaseRepository<DutyEntity>
    {
        public void Create(DutyEntity haircut)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spCreateHaircut @HAIRCUT_ID, @HAIRCUT_TIME, @AVAILABLE, @SALOON_ID," +
                    " @CLIENT_NAME, @CLIENT_EMAIL, @CLIENT_PHONE_NUMBER, @CLIENT_ID", new
                    {
                        HAIRCUT_ID = haircut.Id,
                        HAIRCUT_TIME = haircut.Date,
                        AVAILABLE = haircut.Available,
                        SALOON_ID = haircut.UserID,
                        CLIENT_NAME = CryptoSecurity.Encrypt(haircut.Client.Name),
                        CLIENT_EMAIL = CryptoSecurity.Encrypt(haircut.Client.Email),
                        CLIENT_PHONE_NUMBER = CryptoSecurity.Encrypt(haircut.Client.PhoneNumber),
                        CLIENT_ID = haircut.Client.Id
                    });
            }
        }

        public void Update(DutyEntity haircut)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {

            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spRemoveHaircut @ID", new { ID = id });
            }
            
            return true;
        }
        public List<DutyEntity> GetAll()
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return conn.Query<DutyEntity>("dbo.spGetAllHaircuts").ToList();
            }
        }
        public DutyEntity? GetById(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var haircut = conn.Query<DutyEntity>("dbo.spGetHaircutById @ID", new { ID = id }).FirstOrDefault();
                return haircut == null ? null : haircut;
            }
        }
    }
}