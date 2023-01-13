using Hair.Domain.Entities;

namespace Hair.Repository.Repositories
{
    public class BarberRepository : BaseRepository<BarberEntity>
    {
        public BarberRepository() : base("Barber")
        {
        }
    }
}
