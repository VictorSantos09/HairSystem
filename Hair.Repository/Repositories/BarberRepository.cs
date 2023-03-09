using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Hair.Repository.Repositories
{
    /// <summary>
    /// Repositório responsável por gerenciar as operações de Create e Update para a entidade Barber contida em <see cref="BarberEntity"/>.
    /// </summary>
    public class BarberRepository : IBaseRepository<BarberEntity>
    {
        public static readonly string TableName = "BARBERS";
        public void Create(BarberEntity barber)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                conn.Query("dbo.spCreateBarber");
            }
        }

        public List<BarberEntity> GetAll()
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<BarberEntity>("dbo.spGetAllBarbers").ToList();
            }
        }

        public BarberEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<BarberEntity>("dbo.spGetBarberById", new { ID = id }).FirstOrDefault();   
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