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
    public class DutyRepository : IBaseRepository<DutyEntity>
    {
        public void Create(DutyEntity duty)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spCreateDuty @HAIRCUT_ID, @HAIRCUT_TIME, @SALOON_ID," +
                    " @CLIENT_NAME, @CLIENT_EMAIL, @CLIENT_PHONE_NUMBER, @CLIENT_ID", new
                    {
                        HAIRCUT_ID = duty.Id,
                        HAIRCUT_TIME = duty.Date,
                        SALOON_ID = duty.UserID,
                        CLIENT_NAME = CryptoSecurity.Encrypt(duty.Client.Name),
                        CLIENT_EMAIL = CryptoSecurity.Encrypt(duty.Client.Email),
                        CLIENT_PHONE_NUMBER = CryptoSecurity.Encrypt(duty.Client.PhoneNumber),
                        CLIENT_ID = duty.Client.Id
                    });
            }
        }

        public void Update(DutyEntity duty)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {

            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                conn.Query("dbo.spRemoveDuty @ID", new { ID = id });
            }
            
            return true;
        }
        public List<DutyEntity> GetAll()
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                return conn.Query<DutyEntity>("dbo.spGetAllDuties").ToList();
            }
        }
        public DutyEntity? GetById(Guid id)
        {
            using (IDbConnection conn = ConnectionFactory.BaseConnection())
            {
                var haircut = conn.Query<DutyEntity>("dbo.spGetDutyById @ID", new { ID = id }).FirstOrDefault();
                return haircut == null ? null : haircut;
            }
        }
    }
}