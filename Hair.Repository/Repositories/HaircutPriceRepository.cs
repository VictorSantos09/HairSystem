using Dapper;
using Hair.Domain.Entities;
using Hair.Repository.DataBase;
using Hair.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Repository.Repositories
{
    public class HaircutPriceRepository : IBaseRepository<HaircutPriceEntity>
    {
        public void Create(HaircutPriceEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<HaircutPriceEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public HaircutPriceEntity? GetById(Guid id)
        {
            using (IDbConnection conn = new SqlConnection(DataAccess.DBConnection))
            {
                return conn.Query<HaircutPriceEntity>("dbo.spGetHaircutPriceById @ID", new { ID = id }).FirstOrDefault();
            }
        }

        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(HaircutPriceEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
