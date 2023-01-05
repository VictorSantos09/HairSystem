using Hair.Domain.Entities;
using Repository.Repository;

namespace Hair.Repository.Repositories
{
    public class HaircuteRepository : BaseRepository<HaircuteEntity>
    {
        public HaircuteRepository() : base("HaircuteTime")
        {

        }
    }
}