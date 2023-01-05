using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    public class HaircuteRepository : BaseRepository<HaircuteEntity>
    {
        public HaircuteRepository() : base("HaircuteTime")
        {

        }
    }
}