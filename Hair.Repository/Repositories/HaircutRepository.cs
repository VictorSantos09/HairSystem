using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Classe responsável por implementar as operações de Create e Update de informações sobre salões no banco de dados contida em <see cref="HaircutEntity"/>.
    /// </summary>
    public class HaircutRepository : IBaseRepository<HaircutEntity>
    {
        public HaircutRepository()
        {
        }
        public void Create(HaircutEntity haircut)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.CreateHaircut");
            }
        }

        public void Update(HaircutEntity haircut)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {

            }
        }

        public bool Remove(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spRemoveHaircut", new { ID = id });
                return true;
            }
        }
        public List<HaircutEntity> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<HaircutEntity>("dbo.spGetAllHaircuts").ToList();
            }
        }
        public HaircutEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);

                return conn.Query<HaircutEntity>("dbo.spGetHaircutById", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}